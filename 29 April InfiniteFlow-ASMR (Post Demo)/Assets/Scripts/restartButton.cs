using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restartButton : MonoBehaviour
{
    public gridTest temp1;
    public bool drawMode;
    private bool buttonPressed;
    public bool genPattern;
    public int nodesCount;
    public List<int> AiNodes;
    public List<int> UserNodes;
    private bool check;
    private int hints;
    private bool animate;

    public star star0;
    public star star1;
    public star star2;


    void Start()
    {
        animate = true;
        hints = 3;
        check = false;
        nodesCount = 4;
        drawMode = false;
        genPattern = true;
        animateStar();
    }

    
    void Update()
    {
        if (genPattern)
        {
            hints = 3;
            temp1.DestroyPattern();
            drawMode = false;
            temp1.PatternGenerate(nodesCount);
            AiNodes = new List<int>(temp1.MyDots);
            Invoke("RefreshPattern", nodesCount-0.5f);
            genPattern = false;
        }
        else if (drawMode)
        {
            temp1.PatternDraw();
            if (temp1.PattenDrawnb)
            {
                UserNodes = new List<int> (temp1.dots_List);

                temp1.DestroyPattern();
                if (!CheckPattern())
                {
                    hints--;
                    if (hints == 0)
                    {
                        star0.DieStar();
                    }
                    if (hints == 1)
                    {
                        star1.DieStar();
                    }
                    if (hints == 2)
                    {
                        star2.DieStar();
                    }
                }

                Invoke("gen", 2);   
            }

        }
    }
    public void animateStar()
    {
        star0.transform.Rotate(new Vector3(0, (star0.transform.rotation.y + 4), 0));
        star1.transform.Rotate(new Vector3(0, (star1.transform.rotation.y + 4), 0));
        star2.transform.Rotate(new Vector3(0, (star2.transform.rotation.y + 4), 0));
        if (animate)
        {
            Invoke("animateStar", 0.04f);
        }

    }
    public void RefreshPattern()
    {
        temp1.DestroyPattern();
        drawMode = true;
    }
    public void gen()
    {
        if (CheckPattern())
        {
            star0.GetComponent<SpriteRenderer>().enabled = true;
            star1.GetComponent<SpriteRenderer>().enabled = true;
            star2.GetComponent<SpriteRenderer>().enabled = true;
            genPattern = true;
        }
        else
        {
            foreach (var n in AiNodes)
            {
                temp1.HighlightDotByID(n);
            }
        }
    }

    private bool CheckPattern()
    {
        if(UserNodes.Count == AiNodes.Count)
        {
            for(var c =0; c<UserNodes.Count; c++)
            {
                if(UserNodes[c]!= AiNodes[c])
                {
                    return false;
                }
            }
        }
        else
        {
            return false;
        }
        
        return true;
    }
}
