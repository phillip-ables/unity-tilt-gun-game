using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneScript : MonoBehaviour {
    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.33f; // three seconds

    private void Start()
    {
        fadeGroup = FindObjectOfType<CanvasGroup>();

        fadeGroup.alpha = 1;
    }

    private void Update()
    {
        //Fade-in
        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeInSpeed;
    }

    //Buttons
    public void OnPlayClick()
    {
        Debug.Log("Play button has been clicked!");
    }

    public void OnShopClick()
    {
        Debug.Log("Shop button has been clicked");
    }

    public void OnMultiplayerClick()
    {
        Debug.Log("MultiplayerButton has been clicked");
    }
}
