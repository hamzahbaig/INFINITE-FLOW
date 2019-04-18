using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartButton : MonoBehaviour
{
    public gridTest temp1;
    private bool drawMode;
    private bool buttonPressed;
    // Start is called before the first frame update
    void Start()
    {
        drawMode = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase== TouchPhase.Began)
        {
            //Debug.Log("REFREESHHHH MOTHERFUCCKKEERRRR");
            Vector3 temp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            hit = Physics2D.Raycast(temp, Vector2.zero);
            if (hit.collider != null && hit.transform.gameObject.tag == "refresh")
            {
                if (!buttonPressed)
                {
                    temp1.DestroyPattern();
                    drawMode = false;
                    temp1.PatternGenerate(4);
                    buttonPressed = true;
                    Invoke("RefreshPattern", 2);
                }
                
            }
        }
        if (drawMode)
        {
            temp1.PatternDraw();            
        }
    }
    public void RefreshPattern()
    {
        temp1.DestroyPattern();
        drawMode = true;
        buttonPressed = false;
    }
}
