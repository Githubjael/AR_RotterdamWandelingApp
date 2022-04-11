using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using System.IO;

public class OtherTextApplicator : MonoBehaviour
{
    [SerializeField] Transform UIPanelForText;
    [SerializeField] GameObject UIToString;
    [SerializeField] List<string> fileLines;

    public void ReadFileText()
    {
        string readFromFilePath = Application.streamingAssetsPath + "/Loc1/" + "wandelingTest" + ".txt";

        fileLines = File.ReadAllLines(readFromFilePath).ToList();
    }

    public void DisplayUI()
    {
        foreach(string line in fileLines)
        {
            Instantiate(UIToString, UIPanelForText);
            UIToString.GetComponent<Text>().text = line;
        }
    }
}
