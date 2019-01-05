using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreLoaderScript : MonoBehaviour {
    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minimumLogoTime = 3.0f;  // Minimum time of that scene

    private void Start()
    {
        // Grab the only CanvasGroup in the scene
        fadeGroup = FindObjectOfType<CanvasGroup>();

        fadeGroup.alpha = 1;

        //Preload the game
        // $$

        //appriciate the logo
        if (Time.time < minimumLogoTime)
            loadTime = minimumLogoTime;
        else
            loadTime = Time.time;

    }

    private void Update()
    {
        //fade in
        if(Time.time < minimumLogoTime)
        {
            fadeGroup.alpha = 1 - Time.time;
        }

        //fate-out
        if(Time.time > minimumLogoTime && loadTime != 0)
        {
            if (fadeGroup.alpha >= 1)
                Debug.Log("Change the scene");
        }
    }
}
