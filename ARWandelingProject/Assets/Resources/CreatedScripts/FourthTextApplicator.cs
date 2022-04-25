using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FourthTextApplicator : MonoBehaviour
{
    [SerializeField] TextAsset[] TextFiles;
    [SerializeField] TMP_Text[] UIPanelText;

    private void OnEnable()
    {
        ReadAndDisplay();
    }

    void ReadAndDisplay()
    {
        for(int i = 0; i < TextFiles.Length; i++)
        {
            string textFromFiles = TextFiles[i].text;
            UIPanelText[i].text = textFromFiles;
        }
    }

    void GetTextFiles()
    {
        string path = Application.dataPath + "/Resources/CreatedTextAssets/";
        string[] files = System.IO.Directory.GetFiles(path);
        foreach (string file in files)
        {
            if(!file.EndsWith(".meta"))
            //TextFiles.Add(file);
            Debug.Log(file);
            
        }
    }
}
