using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpdate : MonoBehaviour
{
    void Update()
    {
        PlayerMovement.moveSpeedValue += Time.deltaTime / 500;
    }
}
