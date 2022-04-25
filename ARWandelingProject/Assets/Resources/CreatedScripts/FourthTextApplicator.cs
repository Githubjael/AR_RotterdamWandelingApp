using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourthTextApplicator : MonoBehaviour
{
    [SerializeField] List<TextAsset> TextFiles;
    [SerializeField] List<RectTransform> UIPanels;

    private void OnEnable()
    {
        GetTextFiles();
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
