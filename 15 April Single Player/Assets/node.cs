using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour
{
    public int id;
    public Transform dotSize;
    SpriteRenderer dotSprite;
    private bool animation_scale;
    private bool animationDone;
    Vector3 scale;
    Vector3 color;
    // Start is called before the first frame update
    void Start()
    {
        scale = new Vector3(2.6f, 2.6f, 0);
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
        color = new Vector3(color.x + 0.019f, color.y + 0.019f, color.z + 0.019f);
        dotSprite.color = new Color(color.x,color.y,color.z,1);
        if (animation_scale)
        {

            scale = new Vector3(scale.x + 0.05f, scale.y + 0.05f, 0);
            dotSprite.transform.localScale = scale;
        }
        else
        {
            scale = new Vector3(scale.x - 0.05f, scale.y - 0.05f, 0);
            dotSize.transform.localScale = scale;
            if (scale.x <= 2.6)
            {
                animationDone = true;
            }
        }
        if (scale.x > 3.2f)
        {
            animation_scale = false;

        }
        if (!animationDone)
        {
            Invoke("animateDot", 0.025f);
        }
        else
        {
            color = new Vector3(1.0f, 1.0f, 1.0f);
            dotSprite.color = new Color(color.x, color.y, color.z, 1);
            animationDone = false;
            animation_scale = true;
            return;
        }
    }
}
