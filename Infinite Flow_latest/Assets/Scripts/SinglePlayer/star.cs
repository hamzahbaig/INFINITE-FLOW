using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer starSprite;
    private bool animation_scale;
    private bool animationDone;
    private Color color;
    private Vector3 scale;
    private Color defaultColor;
    private Vector3 defaultScale;
    
    void Start()
    {
        starSprite = GetComponent<SpriteRenderer>();
        animationDone = false;
        animation_scale = true;
        defaultColor = starSprite.color;
        defaultScale = starSprite.transform.localScale;
    }

    
    public void DieStar()
    {
        

        if (animation_scale)
        {
            
            scale = new Vector3(starSprite.transform.localScale.x + 0.004f, starSprite.transform.localScale.y + 0.004f, 0);
            starSprite.transform.localScale = scale;
        }
        else
        {
            starSprite.color = new Color(starSprite.color.r, starSprite.color.g, starSprite.color.b, starSprite.color.a - 0.04f);
            scale = new Vector3(starSprite.transform.localScale.x - 0.01f, starSprite.transform.localScale.y - 0.01f, 0);
            starSprite.transform.localScale = scale;
            if (scale.x <0.01)
            {
                animationDone = true;
            }
        }

        if (scale.x > 0.08f)
        {
            animation_scale = false;

        }
        if (!animationDone)
        {
            Invoke("DieStar", 0.03f);
        }
        else
        {
            //Debug.Log(asd);
            starSprite.color = defaultColor;
            starSprite.transform.localScale = defaultScale;
            starSprite.enabled = false;
            animationDone = false;
            animation_scale = true;
            return;
        }
    }
}
