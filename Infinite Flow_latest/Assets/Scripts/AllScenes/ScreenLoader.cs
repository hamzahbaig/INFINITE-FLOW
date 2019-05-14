using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenLoader : MonoBehaviour
{

    // Use this for initialization
    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
            
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
