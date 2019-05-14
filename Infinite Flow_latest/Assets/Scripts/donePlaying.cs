using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donePlaying : MonoBehaviour
{

    private List<GameObject> stars;
    public restartButton hintSource;
    private int hintCounter;
    public bool doneRating;
    private bool wait;

    void Start()
    {
        wait = false;
        doneRating = true;
        stars = new List<GameObject>();
        foreach (Transform child in transform)
        {
            stars.Add(child.gameObject);
            dimObject(child.gameObject);
        }
       // RatePlayer();
    }
    private void dimObject(GameObject x)
    {
        SpriteRenderer t = x.GetComponent<SpriteRenderer>();
        t.color = Color.gray;
    }
    private void lightObject(GameObject x)
    {
        SpriteRenderer t = x.GetComponent<SpriteRenderer>();
        t.color = Color.white;
    }

    public void RatePlayer()
    {
        hintCounter = hintSource.hints;
        doneRating = false;
        Invoke("RatePlayerHelper",2.0f);
    }

    public void RatePlayerHelper()
    {
        if (hintCounter > 0 )
        {
            hintCounter--;
            lightObject(stars[hintCounter]);
            Invoke("RatePlayerHelper", 2.0f);
        }
        else if(wait)
        {
            doneRating = true;
            wait = false;
            foreach (var st in stars)
            {
                dimObject(st);
            }
        }
        else
        {
            wait = true;
            Invoke("RatePlayerHelper", 2.0f);
        }
    }

    
    


    
}
