using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class node : MonoBehaviour
{
    public int id;
    public bool white;
    public Transform dotSize;
    SpriteRenderer dotSprite;
    private bool animation_scale;
    private bool animationDone;
    Vector3 scale;
    Vector3 color;
    public bool animD;
    // Start is called before the first frame update
    void Start()
    {
        white = false;
        scale = new Vector3(1.07f, 1.07f, 0);
        color = new Vector3(0.5f, .5f, 0.5f);
        animation_scale = true;
        animationDone = false;
        dotSprite = GetComponent<SpriteRenderer>();
        //animateDot();

        //m_SpriteRenderer.color = Color.gray;
    }
    // Update is called once per frame
    public void HighlightDot()
    {
        dotSprite = GetComponent<SpriteRenderer>();
        dotSprite.color = Color.white;
    }
    public void GrayDot()
    {
        dotSprite = GetComponent<SpriteRenderer>();
        dotSprite.color = Color.grey;
    }

    public void animateDot()
    {
    
        if (animation_scale)
        {
            color = new Vector3(color.x + 0.019f, color.y + 0.019f, color.z + 0.019f);
            dotSprite.color = new Color(color.x, color.y, color.z, 1);

            scale = new Vector3(scale.x + 0.05f, scale.y + 0.05f, 0);
            dotSprite.transform.localScale = scale;
        }
        else
        {
            if (white)
            {
                color = new Vector3(color.x + 0.019f, color.y + 0.019f, color.z + 0.019f);
            }
            else
            {
                color = new Vector3(color.x - 0.019f, color.y - 0.019f, color.z - 0.019f);
            }
            dotSprite.color = new Color(color.x, color.y, color.z, 1);
            scale = new Vector3(scale.x - 0.05f, scale.y - 0.05f, 0);
            dotSize.transform.localScale = scale;
            if (scale.x <= 1.07)
            {
                animationDone = true;
            }
        }

        if (scale.x > 1.7f)
        {
            animation_scale = false;

        }
        if (!animationDone)
        {
            Invoke("animateDot", 0.025f);
        }
        else
        {
            animD = true;
            color = new Vector3(1.0f, 1.0f, 1.0f);
            if (white)
            {
                dotSprite.color = new Color(color.x, color.y, color.z, 1);
            }
            else
            {
                dotSprite.color = Color.gray;
            }
            animationDone = false;
            animation_scale = true;
            return;
        }
    }
}
