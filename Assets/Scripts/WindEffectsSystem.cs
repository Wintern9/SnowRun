using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffectsSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem ParticleWind;
    [SerializeField] private Camera Camera;

    private Animator CameraAnimator;

    void Start()
    {
        CameraAnimator = Camera.gameObject.GetComponent<Animator>();
        
        Invoke("GenericEventWind", Random.Range(40f, 60f));
    }

    void GenericEventWind()
    {
        ParticleWind.gameObject.SetActive(false);
        if (Random.Range(0,2) != 1)
        {
            Debug.Log("�������� ���");
            
            var Module = ParticleWind.main;
            Module.loop = true;
            ParticleWind.gameObject.SetActive(true);

            CameraAnimator.SetBool("Wind", true);
            
            Invoke("StopEventWind", Random.Range(40f,60f));
        } else
        {
            Invoke("GenericEventWind", Random.Range(40f, 60f));
            
            Debug.Log("�������� ���");
        }
    }

    void StopEventWind()
    {
        Debug.Log("�������� ����");
        var Module = ParticleWind.main;
        Module.loop = false;
        CameraAnimator.SetBool("Wind", false);
        Invoke("GenericEventWind", Random.Range(40f, 60f));
    }
}
