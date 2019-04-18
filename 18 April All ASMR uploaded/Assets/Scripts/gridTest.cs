using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class gridTest : MonoBehaviour
{
    private List<int> dots_List;
    private bool unlocking;
    private List<node> patternDrawn;
    private node dotOnEdit;
    public GameObject line;
    private drawLine Line;
    private node prevDot;
    private List<node> AllDots;

    private node AIPattern;

    private List<int> MyDots;

    // Start is called before the first frame update
    void Start()
    {
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
        //PatternGenerate(4);
    }
    // Update is called once per frame
    void Update()
    {
        //PatternDraw();

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
                        dots_List.Add(dotOnEdit.id);
                        patternDrawn.Add(dotOnEdit);
                        dotOnEdit.animateDot(); ;
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
            if (true)
            {
                DestroyPattern();
            }
        }
    }

    public void DestroyPattern()
    {
        Line.DestroyEverything();
        foreach (var dot in AllDots)
        {
            dot.GrayDot();
        }
        dots_List.Clear();
        MyDots.Clear();
        unlocking = false;
    }
    public void PatternGenerate(int NoOfDots)
    {
        int temp;

        while(MyDots.Count!=NoOfDots)
        {
            temp = (int) Random.Range(0, 16);
            if (!MyDots.Contains(temp))
            {
                
                MyDots.Add(temp);
                //Debug.Log(temp);
            }
        }
        

        for (int i = 0; i < NoOfDots-1; i++)
        {
            Line.CreateLine(AllDots[MyDots[i]].dotSize.position, AllDots[MyDots[i+1]].dotSize.position);
        }
        for (int i = 0; i < NoOfDots; i++)
        {
            AllDots[MyDots[i]].animateDot();
        }
    }
}
