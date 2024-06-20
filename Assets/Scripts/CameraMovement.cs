using NTC.MonoCache;
using UnityEngine;

public class CameraMovement : MonoCache
{
    [SerializeField] private GameObject player;

    Vector3 vec2;
    Vector3 vec3;
    Vector3 vec;

    void Start()
    {
        vec2 = player.transform.position;
        vec3 = gameObject.transform.position;
        vec = gameObject.transform.position;
    }

    protected override void LateRun()
    {
        vec.x = vec3.x + (player.transform.position.x - vec2.x);
        gameObject.transform.position = vec;
    }
}
