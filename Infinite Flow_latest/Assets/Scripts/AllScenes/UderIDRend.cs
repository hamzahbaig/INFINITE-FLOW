using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class UderIDRend : MonoBehaviour
{
    // Start is called before the first frame update
    public Text UserIDText;
    private void Start()
    {
        UserIDText.text = NickName.nickName;
    }
}
