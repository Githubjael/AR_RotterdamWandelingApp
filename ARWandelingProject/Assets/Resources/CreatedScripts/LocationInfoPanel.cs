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
    [ExecuteInEditMode]
    public void Start()
    {
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
            if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Mouse0))
            {
                ListOfTexts.SetActive(true);
                ListChildren();
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

        for (int i = 0; i < listOfPanels.Count; i++)
        {
            if (listOfPanels[i] != null)
            {
                listOfPanels[0].gameObject.SetActive(true);
            }
        }
    }
}
