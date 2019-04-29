using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

    }
}
public class History
{
    public static bool[] activeList = new bool[] { false, false, false, false, false, false, false, false };
    public static float[] sliderValue = new float[] { 1, 1, 1, 1, 1, 1};

}
