using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("Solo_1-10");
    }

    public void OnShopClick()
    {
        //I think this will morph into the meta data for 
        //Achievments
        Debug.Log("Shop button has been clicked");
    }

    public void OnMultiplayerClick()
    {
        Debug.Log("MultiplayerButton has been clicked");
    }
}
