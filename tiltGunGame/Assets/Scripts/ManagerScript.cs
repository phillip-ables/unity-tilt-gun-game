using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScript : MonoBehaviour
{
    public bool isAccelerometer;

    private Dictionary<int, Vector2> activeTouches = new Dictionary<int, Vector2>();

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

        //read all touches from the user
        Vector3 r = Vector3.zero;
        foreach(Touch touch in Input.touches)
        {
            // If we just started pressing
            if(touch.phase == TouchPhase.Began)
            {
                activeTouches.Add(touch.fingerId, touch.position);
            }
            // If we remove our finger
            else if(touch.phase == TouchPhase.Ended)
            {
                if (activeTouches.ContainsKey(touch.fingerId))
                    activeTouches.Remove(touch.fingerId);
            }
            // finger not moving
            //use delta from origional position
            else
            { 
                float mag = 0;
                r = (touch.position - activeTouches[touch.fingerId]);
                mag = r.magnitude / 300;
                r = r.normalized * mag;
            }
        }
        return r;
    }


}