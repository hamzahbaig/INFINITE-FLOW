using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gridTest : MonoBehaviour
{
    public List<int> dots_List;
    private bool unlocking;
    private List<node> patternDrawn;
    private node dotOnEdit;
    public GameObject line;
    private drawLine Line;
    private node prevDot;
    public List<node> AllDots;
    public bool PattenDrawnb;
    private int noOfAiDots;
    public bool doneAIDraw;
    public SpriteRenderer glowTouch;
    private RaycastHit2D hit;
    public List<int> MyDots;
    public bool showHint;
    
    void Start()
    {
        showHint = false;
        noOfAiDots = 0;
        doneAIDraw = false;
        PattenDrawnb = false;
        patternDrawn = new List<node>();
        AllDots = new List<node>();
        unlocking = false;
        dots_List = new List<int>();
        Line = line.GetComponent<drawLine>();
        MyDots = new List<int>();

        for (int i = 0; i < transform.childCount; i++) //assigning ids to all dots
        {
            var dot = transform.GetChild(i);
            var identifier = dot.GetComponent<node>();
            identifier.id = i;
            AllDots.Add(identifier);
        }
        
    }


    public void PatternDraw() {
        
        if (Input.touchCount > 0)
        {
            PatternDrawHelper();
        }
        else
        {
            if (unlocking)
            {
                PattenDrawnb = true;
            }
        }
    }

    public void PatternDrawHelper()
    {
        Vector3 temp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);


        hit = Physics2D.Raycast(temp, Vector2.zero);
        
        
        if (!unlocking)
        {
            if (hit.collider != null && hit.transform.gameObject.tag == "dot")
            {
                unlocking = true;
                dotOnEdit = hit.transform.gameObject.GetComponent<node>();
                Line.InitializeLine(dotOnEdit.dotSize.position);
                dotOnEdit.white = true;
                dotOnEdit.animateDot();
                dotOnEdit.audioData.Play(0);

                dots_List.Add(dotOnEdit.id);
                patternDrawn.Add(dotOnEdit);
            }
        }
        else
        {
            if (hit.collider != null && hit.transform.gameObject.tag == "dot")
            {
                Line.SpawnLineGenerator(dotOnEdit.dotSize.position);
                node tempdot = hit.transform.GetComponent<node>();

                if (!dots_List.Contains(tempdot.id))
                {
                    prevDot = dotOnEdit;
                    dotOnEdit = tempdot;

                    Line.CreateLine(dotOnEdit.dotSize.position, prevDot.dotSize.position);
                    Line.InitializeLine(dotOnEdit.dotSize.position);

                    dotOnEdit.white = true;
                    dotOnEdit.animateDot();
                    dotOnEdit.audioData.Play(0);
                    dots_List.Add(dotOnEdit.id);
                    patternDrawn.Add(dotOnEdit);

                }
                else
                {
                    Line.SpawnLineGenerator(temp);
                }
            }
            else
            {
                Line.SpawnLineGenerator(temp);
            }
        }
    }
    public void HighlightDotByID(int idd)
    {
        AllDots[idd].animateDot();
    }
    public void DimDotById(int idd)
    {
        AllDots[idd].GrayDot();
    }

    public void DestroyPattern()
    {
        Line.DestroyEverything();
        foreach (var dot in AllDots)
        {
            dot.white = false;
            dot.SetDefaultCollider();
            dot.GrayDot();
        }
        dots_List.Clear();
        MyDots.Clear();
        unlocking = false;
        PattenDrawnb = false;
    }
    public int PatternGenerate(int NoOfDots)
    {
        int temp;

        List<List<int>> tempDots = new List<List<int>>();
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                List<int> x = new List<int>() { i ,j};
                tempDots.Add(x);
            }
        }

        while (MyDots.Count<NoOfDots)
        {
            temp = (int) Random.Range(0, 16);
            if (!MyDots.Contains(temp))
            {
                if(MyDots.Count>0)
                {
                    int t = MyDots[MyDots.Count - 1]; 
                    List<int> add = addInbetween(t, temp, tempDots,MyDots);
                    if (add.Count > 0)
                    {
                        NoOfDots += (add.Count - 1);
                    }
                    foreach (var addDot in add)
                    {
                        if (!MyDots.Contains(addDot))
                        {
                            MyDots.Add(addDot);
                        }
                    }
                }
                if (!MyDots.Contains(temp))
                {
                    MyDots.Add(temp);
                }
            }
        }
        cc = 0;
        noOfAiDots = MyDots.Count;
        doneAIDraw = false;
        GenHelper();
        return MyDots.Count;
    }

    private List<int> addInbetween(int dot1, int dot2, List<List<int>> tempDots, List<int> curDots)
    {
        
        List<int> dot1C = tempDots[dot1];
        List<int> dot2C = tempDots[dot2];

        int xDiff = (dot2C[0] - dot1C[0]) ;
        int yDiff = (dot2C[1] - dot1C[1]) ;
        
        List<int> returnDot = new List<int>();
        if (Mathf.Abs(yDiff) == Mathf.Abs(xDiff))
        {
            if (Mathf.Abs(xDiff) > 1)
            {
                for (int i = 1; i < Mathf.Abs(xDiff); i++)
                {
                    int xC = dot1C[0] + ((xDiff / Mathf.Abs(xDiff)) * i);
                    int yC = dot1C[1] + ((yDiff / Mathf.Abs(yDiff)) * i);
                    if (!curDots.Contains((xC * 4 + yC)))
                    {
                        returnDot.Add(xC * 4 + yC);
                    }
                }
            }
        }
        else if(xDiff == 0 && Mathf.Abs(yDiff)>1)
        {
            for (int i = 1; i < Mathf.Abs(yDiff); i++)
            {       
                int xC = dot1C[0];
                int yC = dot1C[1] + (yDiff / Mathf.Abs(yDiff)) * i;
                if (!curDots.Contains((xC * 4 + yC)))
                {
                    returnDot.Add(xC * 4 + yC);
                }
            }
        }
        else if (yDiff == 0 && Mathf.Abs(xDiff) > 1)
        {
            for (int i = 1; i < Mathf.Abs(xDiff); i++)
            {
                int xC = dot1C[0] + (xDiff / Mathf.Abs(xDiff)) * i;
                int yC = dot1C[1];
                if (!curDots.Contains((xC * 4 + yC)))
                {
                    returnDot.Add(xC * 4 + yC);
                }
            }
        }
        return returnDot;
    }

    public void growLineFT()
    {
        Line.GrowLine(AllDots[0].dotSize.position, AllDots[13].dotSize.position);
    }

    private int cc;
    public void GenHelper()
    {
        if (Line.DoneGrowing || cc == 0)
        {
            AllDots[MyDots[cc]].animateDot();
            Line.GrowLine(AllDots[MyDots[cc]].dotSize.position, AllDots[MyDots[cc + 1]].dotSize.position);

            AllDots[MyDots[cc]].white = true;
            AllDots[MyDots[cc + 1]].white = true;
            
            
            cc++;
            if (cc != noOfAiDots - 1)
            {
                Invoke("GenHelper", 0.05f);
            }
            else
            {
                updateDoneAI();
            }
        }
        else
        {
            Invoke("GenHelper", 0.05f);
        }
        
    }
    private void updateDoneAI() {
        if (Line.DoneGrowing)
        {
            AllDots[MyDots[cc]].animateDot();
            cc = 0;
            doneAIDraw = true;
        }
        else
        {
            Invoke("updateDoneAI", 0.05f);
        }
        
    }


}
