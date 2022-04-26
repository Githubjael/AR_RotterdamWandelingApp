using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using TMPro;
using System.Text;

public class FourthTextApplicator : MonoBehaviour
{
    [SerializeField] TextAsset[] TextFiles;
    [SerializeField] TMP_Text[] UIPanelHeaderText;
    [SerializeField] TMP_Text[] UIPanelSubText;

    private void OnEnable()
    {
        ReadAndDisplay();
    }

    void ReadAndDisplay()
    {
        for(int i = 0; i < TextFiles.Length; i++)
        {
            /*string[] headerTextFromFiles = File.ReadAllLines("Assets/Resources/CreatedTextAssets/.txt", Encoding.UTF8);
            foreach (string headerText in headerTextFromFiles)
            {
                UIPanelHeaderText[i].text = headerText;
            }*/
            string textFromFiles = TextFiles[i].text;
            UIPanelSubText[i].text = textFromFiles;
        }
    }
}
