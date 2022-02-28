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
    public List<string> listOfbuildingNames;
    
    RaycastHit hitInfo;

    public void Update()
    {
        OpenInfoPanel();
    }
    public void OpenInfoPanel()
    {
        if (responsiveReticle.isInteractable)
        {
            if (!IslistedBuildings)
            {
                ListObjects();
            }
            if (!IsListedUIPanels)
            {
                ListPanelUIChildren();
            }
            InputDetection();
        }
    }
    public void ListObjects()
    {
        foreach(Transform objects in LocationObjects)
        {
            listOfbuildingNames.Add(objects.name.ToString());
            listOfObjects.Add(objects);
        }
    }
    public void ListPanelUIChildren()
    {
        foreach(RectTransform child in LocationInfoTexts)
        {
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
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began|| Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Debug.Log("Bogus");
            Debug.Log(ListOfTexts.activeSelf);
            Debug.Log(ListOfTexts.activeInHierarchy);
            ListOfTexts.gameObject.SetActive(true);
            Debug.Log(ListOfTexts.activeSelf);
            Debug.Log(ListOfTexts.activeInHierarchy);
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
