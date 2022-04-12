using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using System.IO;

public class OtherTextApplicator : MonoBehaviour
{
    [SerializeField] string[] LocationFileNames;
    [SerializeField] List<Transform> UIPanelForText;
    [SerializeField] GameObject UIToString;
    [SerializeField] List<string> fileLines;

    public void Awake()
    {
        ReadFileText();
        DisplayUI();
    }
    public void ReadFileText()
    {
        for(int t = 0;  t < UIPanelForText.Count; t++)
        {
            string readFromFilePath = Application.streamingAssetsPath + "/Loc1/" + "wandelingTest" + ".txt";
            fileLines = File.ReadAllLines(readFromFilePath).ToList();
        }
    }

    public void DisplayUI()
    {
        foreach(string line in fileLines)
        {
            for(int i = 0; i < UIPanelForText.Count; i++)
            {
                Instantiate(UIToString, UIPanelForText[i]);
                UIToString.GetComponent<Text>().text = line;
            }
        }
    }
}
