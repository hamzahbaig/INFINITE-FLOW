using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    // Start is called before the first frame update
   public void muteEnabled() 
   {
        GameObject myGameObject;
        GameObject temp;
        for (int index = 0; index < 6; index++)
        {
            History.sliderValue[index] = 1;
            //myImage.color = Color.grey;
            History.activeList[index] = false;
        }
        temp = GameObject.Find("Options and Tools Container");
        string name = "Options and Tools Container";
        myGameObject = GameObject.Find("AudioManager");
        for(int i =1; i <= 6;i++)
        {
            GameObject asmr = temp.transform.GetChild(i).gameObject;
            Image myImage = asmr.transform.GetChild(0).gameObject.GetComponent<Image>();
            Slider mySlider = asmr.transform.GetChild(1).gameObject.GetComponent<Slider>();
            myImage.color = Color.grey;
            mySlider.value = 1;
    
        }

        AudioSource[] audioSources = myGameObject.GetComponents<AudioSource>();
        foreach (AudioSource item in audioSources)
        {
           Destroy(item);
        }

    }
    

}
