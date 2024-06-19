using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    [SerializeField] private GameObject ColliderDeletes;
    [SerializeField] private GameObject UIRestart;

    Rigidbody rg;
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("log"))
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("log"))
        {
            rg.freezeRotation = false;
            gameObject.GetComponent<PlayerMovement>().enabled = false;
            ColliderDeletes.SetActive(false);
            UIRestart.SetActive(true);
        }
    }
}
