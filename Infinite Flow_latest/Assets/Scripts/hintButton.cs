using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintButton : MonoBehaviour
{
    public bool giveHint;
    void Start()
    {
        giveHint = false;
    }

    public void giveHintFunc()
    {
        giveHint = true;
    }
    public void disableHintFunc()
    {
        giveHint = false;
    }

}
