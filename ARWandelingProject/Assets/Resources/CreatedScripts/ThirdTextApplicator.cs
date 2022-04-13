using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ThirdTextApplicator : MonoBehaviour
{
    [SerializeField] Transform UIPanel;
    string fileText;
    [SerializeField] GameObject UITextObject;

    private void OnEnable()
    {
        ReadTextfiles();
        DisplayText();
    }

    void ReadTextfiles()
    {
        fileText = Resources.Load<TextAsset>("CreatedTextAssets/wandelingTest 1").text;
    }

    void DisplayText()
    {
        UITextObject.GetComponent<Text>().text = fileText;
        Instantiate(UITextObject, UIPanel);
    }
}
