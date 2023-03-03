using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    [SerializeField]
    Image color;
    [SerializeField]
    TMPro.TMP_Text playerText;

    public void SetColorAndText(Color col, string text)
    {
        color.color = col;
        playerText.text = text;
    }
    
}
