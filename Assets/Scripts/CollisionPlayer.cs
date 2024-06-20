using UnityEngine;
using NTC.MonoCache;

public class CollisionPlayer : MonoCache
{
    [SerializeField] private GameObject ColliderDeletes;
    [SerializeField] private GameObject UIRestart;

    Rigidbody rg;
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody>();
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
