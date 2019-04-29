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

    public List<int> MyDots;

    // Start is called before the first frame update
    void Start()
    {
        noOfAiDots = 0;
        PattenDrawnb = false;
        patternDrawn = new List<node>();
        AllDots = new List<node>();
        unlocking = false;
        dots_List = new List<int>();
        Line = line.GetComponent<drawLine>();
        MyDots = new List<int>();
        

        for (int i = 0; i < transform.childCount; i++) //assigning ids to all cells
        {
            var dot = transform.GetChild(i);
            var identifier = dot.GetComponent<node>();
            identifier.id = i;
            AllDots.Add(identifier);
        }
    }

    public void PatternDraw() {
        RaycastHit2D hit;
        if (Input.touchCount > 0)
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
                    dotOnEdit.animateDot(); ;
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
                        dotOnEdit.animateDot();
                        dots_List.Add(dotOnEdit.id);
                        patternDrawn.Add(dotOnEdit);
                        
                    }
                }
                else
                {
                    Line.SpawnLineGenerator(temp);
                }
            }
        }
        else
        {
            if (unlocking)
            {
                PattenDrawnb = true;
            }
            //DestroyPattern();   
        }
    }
    public void HighlightDotByID(int idd)
    {
        AllDots[idd].animateDot();
        //while (!AllDots[idd].animD);
        //AllDots[idd].animD = false;
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
            dot.GrayDot();
        }
        dots_List.Clear();
        MyDots.Clear();
        unlocking = false;
        PattenDrawnb = false;
    }
    public void PatternGenerate(int NoOfDots)
    {
        int temp;
        noOfAiDots = NoOfDots;
        while(MyDots.Count!=NoOfDots)
        {
            temp = (int) Random.Range(0, 16);
            if (!MyDots.Contains(temp))
            {                
                MyDots.Add(temp);
            }
        }
        cc = 0;
        GenHelper();
    }
    private int cc;
    public void GenHelper()
    {
        
        Line.CreateLine(AllDots[MyDots[cc]].dotSize.position, AllDots[MyDots[cc + 1]].dotSize.position);
        AllDots[MyDots[cc]].white = true;
        AllDots[MyDots[cc+1]].white = true;

        AllDots[MyDots[cc]].animateDot();
        AllDots[MyDots[cc+1]].animateDot();
        cc++;
        if (cc != noOfAiDots-1)
        {
            Invoke("GenHelper", 1);
        }
    }


}
