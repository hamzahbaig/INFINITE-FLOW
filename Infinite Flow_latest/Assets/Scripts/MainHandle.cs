using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHandle : MonoBehaviour
{
    public donePlaying ratingSystem;
    public gridTest patternDrawer;
    public restartButton drawManager;
    public GameObject postProcessingCam;
    public GameObject ratePlayerCamera;
    private string scriptName;

    void Start()
    {
        scriptName = "SuperBlurFast";
        (postProcessingCam.GetComponent(scriptName) as MonoBehaviour).enabled = false;
        ratePlayerCamera.GetComponent<Camera>().enabled = false;
        Invoke("stg", 2.0f);
    }
    private void stg()
    {
        drawManager.startGame();
    }

    void Update()
    {
        if (drawManager.levelDone)
        {
            Debug.Log("DONE");
            drawManager.levelDone = false;
            Invoke("levelDoneFunc", 1.0f);
            //drawManager.levelDone = false;
        }
    }
    private void levelDoneFunc()
    {
        (postProcessingCam.GetComponent(scriptName) as MonoBehaviour).enabled = true;
        ratePlayerCamera.GetComponent<Camera>().enabled = true;
        ratingSystem.RatePlayer();
        checkForRating();
    }
    private void checkForRating()
    {
        if (!ratingSystem.doneRating)
        {
            Invoke("checkForRating", 0.5f);
        }
        else
        {
            (postProcessingCam.GetComponent(scriptName) as MonoBehaviour).enabled = false;
            ratePlayerCamera.GetComponent<Camera>().enabled = false;
            drawManager.genPattern = true;
        }
    }
}
