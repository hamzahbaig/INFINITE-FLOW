using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawLine : MonoBehaviour
{
    [SerializeField]
    // Start is called before the first frame update
    private GameObject LineGenPrefab;
    private GameObject lineOnEdit;
    public List<GameObject> lines;
    public Camera maincamera;
    LineRenderer lRendOnEdit;
    void Start()
    {
        
        //lRendOnEdit.SetPosition(0, new Vector3(0,0,0));
    }
    public void InitializeLine(Vector3 from)
    {
        lineOnEdit = Instantiate(LineGenPrefab);
        lRendOnEdit = lineOnEdit.GetComponent<LineRenderer>();
        lRendOnEdit.SetPosition(0, from);
        lRendOnEdit.SetPosition(1, from);
        lRendOnEdit.numCornerVertices = 5;
        //lRendOnEdit.SetWidth(0, 3);
        lines.Add(lineOnEdit);
    }

    public void SpawnLineGenerator(Vector3 to)
    {
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
    // Update is called once per frame
    void Update()
    {
        /*if (Input.touchCount == 1)
        {
            Vector3 to = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            SpawnLineGenerator(to);

        }*/
    }
}
