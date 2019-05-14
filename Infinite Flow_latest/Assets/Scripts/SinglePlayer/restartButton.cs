using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class restartButton : MonoBehaviour
{
    public gridTest temp1;
    public bool drawMode;
    public bool genPattern;
    public int nodesCount;
    public List<int> AiNodes;
    public List<int> UserNodes;

    
    public int hints;
    private bool animate;
    private int myCounter;
    private bool disableHint;
    public bool levelDone;

    public star star0;
    public star star1;
    public star star2;

    public hintButton hintButtonObj;

    void Start()
    {
        myCounter = 0;
        animate = true;
        hints = 3;
       
        nodesCount = 4;
        drawMode = false;
        levelDone = false;
        genPattern = false;
        animateStar();
        disableHint = true;
        //Invoke("startGame", 1);
    }

    public void startGame() {
        genPattern = true;
        CheckHint();
    }

    private void CheckHint()
    {
        if (hintButtonObj.giveHint)
        {
            hintButtonObj.disableHintFunc();
            
            if (!disableHint) 
            {
                disableHint = true;
                Hint();
            }
        }
        Invoke("CheckHint", 0.1f);
        

    }

    public void Hint() {
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

        myCounter = 0;
        hightlighAI();
        drawMode = false;
        genPattern = false;

    }

    private void addDelay() {
        

        nodesCount = temp1.PatternGenerate(4);
        AiNodes = new List<int>(temp1.MyDots);
        RefreshPattern();
        
    }
    void Update()
    {

        if (genPattern)
        {
            disableHint = true;
            hints = 3;
            temp1.DestroyPattern();
            drawMode = false;
            genPattern = false;
            Invoke("addDelay", 1.0f);
        }
        else if (drawMode)
        {
            disableHint = false;
            temp1.PatternDraw();

            if (temp1.PattenDrawnb)
            {
                UserNodes = new List<int> (temp1.dots_List);
                temp1.DestroyPattern();
                gen();
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
        if (temp1.doneAIDraw)
        {
            temp1.DestroyPattern();
            foreach (var n in AiNodes)
            {
                temp1.AllDots[n].SetBigCollider();
            }
            disableHint = false;
            drawMode = true;
        }
        else
        {
            Invoke("RefreshPattern", 1);
        }
        
        
    }
    public void gen()
    {
        if (CheckPattern())
        {
            star0.GetComponent<SpriteRenderer>().enabled = true;
            star1.GetComponent<SpriteRenderer>().enabled = true;
            star2.GetComponent<SpriteRenderer>().enabled = true;
           // genPattern = true;
            drawMode = false;
            levelDone = true;
        }
        else
        {
            foreach (var d in AiNodes)
            {
                temp1.AllDots[d].myCollider.radius = 0.2f;
            }
        }
    }

    private void hightlighAI()
    {
        if (myCounter < AiNodes.Count)
        {
            temp1.HighlightDotByID(AiNodes[myCounter]);
            temp1.AllDots[AiNodes[myCounter]].myCollider.radius = 0.2f;
            myCounter++;
            disableHint = true;   
            Invoke("hightlighAI", 0.3f);
        }
        else
        {
            myCounter = 0;
            genPattern = false;
            drawMode = true;
            disableHint = false;
            return;
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
