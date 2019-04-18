using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorShift : MonoBehaviour
{
    SpriteRenderer frameSprite;
    private float r;
    private float g;
    private float b;
    private float a;
    bool glow;

    // Start is called before the first frame update
    void Start()
    {
        glow = false;
        r = 0.8549f;
        g = 0.5725f;
        b = 0.8509f;
        a = 1.0f;
        frameSprite = GetComponent<SpriteRenderer>();
        changeColor();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void changeColor()
    {
        if (glow)
        {
            a += 0.01f;
            frameSprite.color = new Color(r, g, b, a);
        }
        else
        {
            a -= 0.01f;
            frameSprite.color = new Color(r, g, b, a);
        }
        if (a < 0.4f)
        {
            glow = true;
            a = 0.4f;
        }
        else if (a > 0.99f)
        {
            glow = false;
            a = 0.99f ;
        }
        Invoke("changeColor",0.05f);
    }
}
