using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public bool isAccelerometer;

    private void Start()
    {
        isAccelerometer = SystemInfo.supportsAccelerometer;
    }

    public Vector3 GetPlayerInput()
    {
        //Are we using the acceleromerer?
        if (isAccelerometer)
        {
            Vector3 acc = Input.acceleration;
            acc.y = acc.z;
            return acc;
        }
            
    }
    

}