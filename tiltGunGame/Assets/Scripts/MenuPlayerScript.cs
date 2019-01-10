using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlayerScript : MonoBehaviour {
    public float waitTime;

    private void Start()
    {
        waitTime = 0.75f;
    }

    private void Update()
    {
        if (waitTime <= 0)
        {
            //Debug.Log("Camera Go!!");
            transform.position += Vector3.forward * 3 * Time.deltaTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
