using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class LocationInfoPanel : MonoBehaviour
{
    public ResponsiveReticle responsiveReticle;
    public Transform LocationInfoTexts;
    public float optionsButtonFontSize;

    public GameObject ListOfTexts;

    public List<RectTransform> listOfPanels;

    public void Start()
    {
        ListChildren();
        optionsButtonFontSize = GetComponentInChildren<TextMeshProUGUI>().fontSize;
    }

    public void Update()
    {
        OpenInfoPanel();
    }

    public void OpenInfoPanel()
    {
        if (responsiveReticle.isInteractable)
        {
            Debug.Log("Ey!");
            if (Input.touchCount > 0)
            {
                ListOfTexts.SetActive(true);
                optionsButtonFontSize = 50f;
            }
            else
            {
                optionsButtonFontSize = 100f;
            }
        }
    }

    public void ListChildren()
    {
        
        foreach(RectTransform child in LocationInfoTexts)
        {
            Debug.Log("Child:" + child.name);
            listOfPanels.Add(child);
        }
        listOfPanels[0].gameObject.SetActive(true);
        for (int i = 0; i < listOfPanels.Count; i++)
        {
            if(listOfPanels[i] != null)
            {

            }
        }
    }
}
