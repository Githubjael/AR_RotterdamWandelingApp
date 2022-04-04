using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class testTextAreaString : MonoBehaviour
{
    [SerializeField] TMP_Text[] UIToFill;
    [SerializeField, TextArea] string[] texts;

    private void Awake()
    {
        StringToTextArea();
    }

    private void StringToTextArea()
    {
        for(int i = 0; i < UIToFill.Length; i++)
        {
            UIToFill[i].text = texts[i];
        }
    }
}
