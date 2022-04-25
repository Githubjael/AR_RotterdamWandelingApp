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
    [SerializeField] string[] LocationfileNames;
    [SerializeField] string[] TextfileNames;
    [SerializeField] RectTransform[] ListofUIPanels;

    private void OnEnable()
    {
        ReadTextfiles();
        DisplayText();
    }

    void ReadTextfiles()
    {
        for(int i  = 0; i < LocationfileNames.Length; i++)
        {
            fileText = Resources.Load<TextAsset>(LocationfileNames[i]+ "/" + TextfileNames).text;
        }
    }

    void DisplayText()
    {
        UITextObject.GetComponent<Text>().text = fileText;
        Instantiate(UITextObject, UIPanel);
    }
}
