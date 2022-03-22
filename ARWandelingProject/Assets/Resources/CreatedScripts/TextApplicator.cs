using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TextApplicator : MonoBehaviour
{
    [SerializeField] TextAsset textfile;
    [SerializeField] string[] tests;
    [SerializeField] GameObject[] UIToFill;
    [SerializeField] TMP_Text[] textsToFill;
    private void Awake()
    {
        ReadFile();
        ApplyText();
    }

    void ReadFile()
    {
        tests = textfile.text.Split(new string[] {",", "\n" }, StringSplitOptions.None);
    }

    void ApplyText()
    {
        for (int i = 0; i < textsToFill.Length; i++)
        {
            textsToFill[i].text = tests[i];
        }
    }
}