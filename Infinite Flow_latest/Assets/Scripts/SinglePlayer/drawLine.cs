using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour
{
    [SerializeField]
    private GameObject LineGenPrefab;
    private GameObject lineOnEdit;
    public List<GameObject> lines;
    public Camera maincamera;
    private LineRenderer lRendOnEdit;
    private Vector3 growLineTo, growLineFrom, growingPoint;
    public SpriteRenderer glow;

    public bool  DoneGrowing;
    private float step;

    private void Start()
    {
        glow.enabled = false;
    }


    public void InitializeLine(Vector3 from)
    {
        lineOnEdit = Instantiate(LineGenPrefab);
        lRendOnEdit = lineOnEdit.GetComponent<LineRenderer>();
        from.z = 1;
        lRendOnEdit.SetPosition(0, from);
        lRendOnEdit.SetPosition(1, from);
        lRendOnEdit.numCornerVertices = 5;
        lines.Add(lineOnEdit);
    }

    public void SpawnLineGenerator(Vector3 to)
    {
        to.z = 1;
        lRendOnEdit.SetPosition(1, to);
    }

    public void CreateLine(Vector3 to , Vector3 from)
    {
        var lin = Instantiate(LineGenPrefab);
        LineRenderer llin = lin.GetComponent<LineRenderer>();
        llin.SetPosition(0, from);
        llin.SetPosition(1, to);
        lines.Add(lin);
    }

    public void GrowLine(Vector3 from , Vector3 to) {
        growLineFrom = from;
        growingPoint = from;
        growLineTo = to;
        DoneGrowing = false;
        step = 0.06f;
        InitializeLine(from);
        glow.transform.position = growingPoint;
        glow.enabled = true;
        GrowLineHelper();
    }
    public void GrowLineHelper() {
        if (Vector3.Distance(growLineTo, growingPoint) < 0.005)
        {
            SpawnLineGenerator(growLineTo);
            glow.transform.position = growingPoint;
            CreateLine(growLineFrom, growLineTo);
            glow.enabled = false;
            DoneGrowing = true;
        }
        else
        {
            growingPoint = Vector3.MoveTowards(growingPoint, growLineTo, step);
            SpawnLineGenerator(growingPoint);
            glow.transform.position = growingPoint;
            Invoke("GrowLineHelper", 0.018f);
            
        }
    }



    public void DestroyEverything()
    {
        foreach(var line in lines)
        {
            Destroy(line);
        }
        lines.Clear();
        lineOnEdit = null;
        lRendOnEdit = null;
    }
}
