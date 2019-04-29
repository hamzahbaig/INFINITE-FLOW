using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class screenChanger : MonoBehaviour {

    private Vector3 fp; // first touch position
    private Vector3 lp; // last touch position
    public Vector3 swipe;
    private float dragDistance; // minimum distance for a swipe to be registered

	// Use this for initialization
	void Start () {
        dragDistance = Screen.height * 15 / 100;	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount == 1)
        {
            Touch touch1 = Input.GetTouch(0);
            if(touch1.phase == TouchPhase.Began)
            {
                fp = touch1.position;
            } else if (touch1.phase == TouchPhase.Ended)
            {
                lp = touch1.position;
                swipe = lp - fp;
                
                // MOVE TO LOGIN SCREEN
                if(swipe.x >= dragDistance)
                {
                    SceneManager.LoadScene(8);
                }
                if (swipe.x <= -dragDistance)
                {
                    SceneManager.LoadScene(8);
                }
            }
        }
		
	}
}
