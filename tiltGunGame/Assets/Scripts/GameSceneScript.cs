using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneScript : MonoBehaviour {
    private CanvasGroup fadeGroup;
    private float fadInDuration = 2;
    private bool gameStarted;
    

    public void ExitScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
