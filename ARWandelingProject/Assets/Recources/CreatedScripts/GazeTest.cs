using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GazeTest : MonoBehaviour, InformationInterface
{
    /// <summary>
    /// This script is for handeling interactions with objects through gazing at them
    /// </summary>
    //get a curssor, we plan on putting this cursor in the middle of the screen
    [SerializeField]
    private GameObject Cursor;
    //the user/player/observer/ person who is holding the phone currently
    [SerializeField]
    private GameObject Observer;
    //this is an gameobject that will hold strings depending on the tag of the observed object
    [SerializeField]
    private GameObject infoPrompt;
    //this is the string that will change depending on the tag
    [SerializeField]
    private TextMeshProUGUI information;

    public void Update()
    {
        Gaze();
    }
    public void Gaze()
    {
        Ray ray = new Ray(Observer.transform.position, Observer.transform.forward);
        RaycastHit hitsInfo;
        if (Physics.Raycast(ray, out hitsInfo))
        {
            if (hitsInfo.collider.tag == "testTag1")
            {
                Debug.DrawLine(ray.origin, hitsInfo.point, Color.green);
                infoPrompt.SetActive(true);
                FillInText("Die on this hill.");
            }
        } 
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.origin + ray.direction * 100, Color.red);
        }
    }

    public void FillInText(string infoText)
    {
        information.text = infoText;
    }
}