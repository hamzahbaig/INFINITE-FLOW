using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 

public class ASMR : MonoBehaviour {
    public Image myImage;
    public GameObject myGameObject;
    public AudioClip myClip;
    private AudioSource myAudioSource;
    public int index;

    void Start()
    {
        if(History.activeList[index] == true)
        {
            myImage.color = Color.white;
        }
    }



    public void buttonPressed()
    {
        //Turning on ASMR
        if(History.activeList[index] == false)
        {
            History.activeList[index] = true;
            myImage.color = Color.white;
            myGameObject = GameObject.Find("AudioManager");
            myAudioSource = myGameObject.AddComponent<AudioSource>();
            myAudioSource.clip = myClip;
            myAudioSource.Play();
            myAudioSource.loop = true;
            print(History.activeList[index]);

        }
        // Turning off ASMR
        else if(History.activeList[index] == true)
        {
           
            myImage.color = Color.grey;
            History.activeList[index] = false;
            myGameObject = GameObject.Find("AudioManager");
            AudioSource[] audioSources = myGameObject.GetComponents<AudioSource>();
            foreach(AudioSource item in audioSources)
            {
                if(item.clip.name == myClip.name)
                {
                    Destroy(item);
                }
            }
            print(History.activeList[index]);

        }

    }
   

}
