using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneScript : MonoBehaviour {
    public Transform menuContainer;

    public AnimationCurve enteringLevelZoomCurve;
    private bool isEnteringLevel = false;
    private float zoomDuration = 3.0f;
    private float zoomTransition;

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

        if (isEnteringLevel)
        {
            // Add to the zoomTransition float
            zoomTransition += (1 / zoomDuration) * Time.deltaTime;

            // Change the scale following the animation curve
            menuContainer.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 5, enteringLevelZoomCurve.Evaluate(zoomTransition));
        }
    }

    //Buttons
    public void OnPlayClick()
    {
        isEnteringLevel = true;
        //SceneManager.LoadScene("Solo_1-10");
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
