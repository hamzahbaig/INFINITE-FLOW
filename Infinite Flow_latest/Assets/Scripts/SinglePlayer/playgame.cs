using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playgame : MonoBehaviour
{
    public GameObject myimage;
    public GameObject thegame;
    // Start is called before the first frame update
   public void playonclick()
    {
        myimage.SetActive(false);
        thegame.SetActive(true);
    }
}
