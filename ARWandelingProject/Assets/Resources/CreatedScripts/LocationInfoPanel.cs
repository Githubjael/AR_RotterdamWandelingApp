using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class LocationInfoPanel : MonoBehaviour
{
    public ResponsiveReticle responsiveReticle;
    public Transform LocationInfoTexts;

    public GameObject ListOfTexts;

    public List<RectTransform> listOfPanels;

    public void Start()
    {
        ListChildren();
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
    }
}
