using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackScreen : MonoBehaviour {

    int index;
    private void Awake()
    {
         index = SceneManager.GetActiveScene().buildIndex;

    }

    // Use this for initialization
    void Start () {
        //ebug.Log(index);

    }

    // Update is called once per frame
    void Update () {

        if (Application.platform == RuntimePlatform.Android)
        {

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(index == 0)
                {
                    Application.Quit();
                }
                // Login Screen
                if(index == 1)
                {
                    SceneManager.LoadScene(0);
                }
                // Main Menu
                if(index == 2)
                {
                    SceneManager.LoadScene(1);
                }
                // Loading Screen
                if(index == 3)
                {
                    SceneManager.LoadScene(2);
                }
                // GameSettings
                if(index == 4)
                {
                    SceneManager.LoadScene(2);
                }
                //TrophyRack
                if(index == 5)
                {
                    SceneManager.LoadScene(2);
                }
                //Multiplayer1
                if(index == 6)
                {
                    SceneManager.LoadScene(2);
                }
                //Multiplayer2
                if(index == 7)
                {
                    SceneManager.LoadScene(6);
                }
                if(index == 8)
                {
                    SceneManager.LoadScene(1);
                }
                // SinglePlayer
                if(index == 9)
                {
                    SceneManager.LoadScene(2);
                    print("Best");
                }

            }
        }
	}
}
