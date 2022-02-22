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
    public Transform LocationObjects;
    public GameObject optionsButton;

    public GameObject ListOfTexts;

    public List<RectTransform> listOfPanels;
    public List<Transform> listOfObjects;

    public void Update()
    {
        OpenInfoPanel();
    }

    public void OpenInfoPanel()
    {
        if (responsiveReticle.isInteractable)
        {
            if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Mouse0))
            {
                ListOfTexts.SetActive(true);
                ListPanelUIChildren();
                ListObjects();
                InputDetection();
            }
        }
    }
    public void ListObjects()
    {
        foreach(Transform objects in LocationObjects)
        {
            Debug.Log("Object:" + objects.name);
            listOfObjects.Add(objects);
        }
    }
    public void ListPanelUIChildren()
    {
        foreach(RectTransform child in LocationInfoTexts)
        {
            Debug.Log("Child:" + child.name);
            listOfPanels.Add(child);
        }
    }
    public void InputDetection()
    {
        #region J.U.C.
/*
        * for (int i = 0; i < listOfPanels.Count; i++)
            {
            if (listOfPanels[i] != null)
            {
                if (listOfObjects[i].gameObject.name == "building01")
                {
                    listOfPanels[0].gameObject.SetActive(true);
                }
                else if (listOfObjects[i].gameObject.name == "building02")
                {

                }
                if (ListOfTexts)
                {
                    optionsButton.gameObject.SetActive(false);
                }
                else
                {
                    optionsButton.gameObject.SetActive(true);
                }
            }
        }
*/
        #endregion
        for(int i = 0; i <= listOfObjects.Count; i++)
        {
            if(listOfObjects[i].gameObject.name == "building02")
            {
                for(int j = 0; j <= listOfPanels.Count; j++)
                {
                    if(listOfPanels[j].gameObject.name == "Building02")
                    {
                        listOfPanels[j].gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
