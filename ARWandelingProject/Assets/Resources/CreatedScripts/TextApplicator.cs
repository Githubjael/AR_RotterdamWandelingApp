using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TextApplicator : MonoBehaviour
{
    [SerializeField] TextAsset textfile;
    [SerializeField] string[] tests;
    [SerializeField] GameObject[] UIToFill;
    private void Awake()
    {
        ReadFile();
    }

    void ReadFile()
    {
        tests = textfile.text.Split(new string[] {",", "\n" }, StringSplitOptions.None);
    }
}
