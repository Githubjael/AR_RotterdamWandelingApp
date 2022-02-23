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
            ListOfTexts.SetActive(true);
            if (!IsListedUIPanels)
            {
                ListPanelUIChildren();
            }
            if (!IslistedBuildings)
            {
                ListObjects();

            }
            if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Mouse0))
            {
                InputDetection();
            }
        }
    }
    public void ListObjects()
    {
        foreach(Transform objects in LocationObjects)
        {
            Debug.Log("hey: " + objects.name);
            listOfObjects.Add(objects);
        }
    }
    public void ListPanelUIChildren()
    {
        foreach(RectTransform child in LocationInfoTexts)
        {
            Debug.Log("hey: " + child.name);
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
        foreach(var buildings in listOfObjects)
        {
            foreach (var panels in listOfPanels)
            {
                if(panels.gameObject.name == buildings.gameObject.name)
                {
                    panels.gameObject.SetActive(true);
                }
            }
        }

    }
    private bool IsListedUIPanels
    {
        get
        {
            if(listOfPanels.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }        
    }
    private bool IslistedBuildings
    {
        get
        {
            if(listOfObjects.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
