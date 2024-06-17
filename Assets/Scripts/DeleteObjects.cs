using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject.transform.root.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
