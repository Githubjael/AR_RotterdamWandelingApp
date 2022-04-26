using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

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
}
