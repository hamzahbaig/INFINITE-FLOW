using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenControl : MonoBehaviour {

    public Slider slider;
	// Use this for initialization
	void Start () {
       // slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        slider.value = 0;

    }

    // Update is called once per frame
    void Update () {
        if(slider.value != 100)
        {
            slider.value += 0.5f;
        } else
        {
            SceneManager.LoadScene(9);
        }
        ValueChangeCheck();
        
		
	}
    void ValueChangeCheck()
    {
        print(slider.value);
    }
}
