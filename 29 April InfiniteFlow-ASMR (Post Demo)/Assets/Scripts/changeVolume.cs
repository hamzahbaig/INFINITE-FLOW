using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class changeVolume : MonoBehaviour
{
    public GameObject myGameObject;
    public AudioClip myClip;
    public Slider myslider;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        myslider.value = History.sliderValue[index];
    }

    // change volume
    public void change()
    {
        
        myGameObject = GameObject.Find("AudioManager");
        AudioSource[] audioSources = myGameObject.GetComponents<AudioSource>();
        foreach (AudioSource item in audioSources)
        {
            print(item);
            if (item.clip.name == myClip.name)
            {
                (item.volume) = myslider.value;
                History.sliderValue[index] = myslider.value;
            }
        }
        
    }
    
}
