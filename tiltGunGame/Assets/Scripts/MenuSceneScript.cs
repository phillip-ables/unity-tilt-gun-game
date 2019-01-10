using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneScript : MonoBehaviour {
    public RectTransform menuContainer;
    //public Transform menuContainer;
    public GameObject gameButton;
    public GameObject multiplayerButton;
    public GameObject shopButton;

    public GameObject currentTrail;
    private MenuCameraScript menuCamera;

    public AnimationCurve enteringLevelZoomCurve;
    private bool isEnteringLevel = false;
    private float zoomDuration = 3.0f;
    private float zoomTransition;

    private CanvasGroup fadeGroup;
    private float fadeInSpeed = 0.33f; // three seconds
    private Vector3 desiredMenuPosition;
    private RectTransform rt;
    private string sceneName;

    private void Start()
    {
        menuCamera = FindObjectOfType<MenuCameraScript>();

        fadeGroup = FindObjectOfType<CanvasGroup>();

        fadeGroup.alpha = 1;

        //??
        SetTrail();
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

            Vector3 newDesiredPosition = desiredMenuPosition * 5;
            newDesiredPosition -= rt.anchoredPosition3D * 5;

            menuContainer.anchoredPosition3D = Vector3.Lerp(desiredMenuPosition, newDesiredPosition, enteringLevelZoomCurve.Evaluate(zoomTransition));

            fadeGroup.alpha = zoomTransition;

            if(zoomTransition >= 1 && sceneName != null)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    private void SetTrail()
    {
        // Change the trail on player model
        if (currentTrail != null)
        {
            Destroy(currentTrail);
        }

        //Set the active index
        currentTrail = Instantiate(currentTrail) as GameObject;

        //Create the new trail
        //return to video 13 time 6 oh 3

        //Set it as a child of the player
        currentTrail.transform.SetParent(FindObjectOfType<MenuPlayerScript>().transform);

        //Fix the wierd scaling issues / rotation
        currentTrail.transform.localPosition = Vector3.zero;
        currentTrail.transform.localRotation = Quaternion.Euler(0, 0, 90);
        currentTrail.transform.localScale = Vector3.one * 0.01f;
        //Change buy/set button text

        //Remember preferences
    }

    //Buttons
    public void OnPlayClick()
    {
        desiredMenuPosition = gameButton.transform.position;
        rt = gameButton.GetComponent<RectTransform>();
        //SceneManager.LoadScene("Solo_1-10");
        sceneName = "Solo_1-10";
        isEnteringLevel = true;
    }

    public void OnShopClick()
    {
        isEnteringLevel = true;
        desiredMenuPosition = shopButton.transform.position;
        rt = shopButton.GetComponent<RectTransform>();
        //I think this will morph into the meta data for 
        //Achievments
        sceneName = null;
        menuCamera.MoveToShop();
        Debug.Log("Shop button has been clicked");
    }

    public void OnMultiplayerClick()
    {
        isEnteringLevel = true;
        desiredMenuPosition = multiplayerButton.transform.position;
        rt = multiplayerButton.GetComponent<RectTransform>();
        Debug.Log("MultiplayerButton has been clicked");
        sceneName = null;
    }

    public void BackClick()
    {
        menuCamera.BackToMainMenu();
    }
}
