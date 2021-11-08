using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GazeTest : MonoBehaviour, InformationInterface
{
    //get a curssor, we plan on putting this cursor in the middle of the screen
    [SerializeField]
    private GameObject Cursor;
    //the user/player/observer/ person who is holding the phone currently
    [SerializeField]
    private GameObject Observer;
    //this is an gameobject that will hold 
    [SerializeField]
    private GameObject infoPrompt;
    //this is the string that will change depending on the tag
    [SerializeField]
    private TextMeshProUGUI information;

    public void FixedUpdate()
    {
        Gaze();
    }
    public void Gaze()
    {
        Ray ray = new Ray(Observer.transform.position, Observer.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.green);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);
        }
        Debug.DrawRay(ray.origin, hitInfo.point, Color.grey);
        Debug.Log($"{hitInfo.collider.tag}");
        if (hitInfo.collider.tag == "TestTag1")
        {
            Debug.Log("Hello!");
            infoPrompt.SetActive(true);
            FillInText("What is up Jared?");
        }
        if(hitInfo.collider.tag == "Untagged")
        {
            infoPrompt.SetActive(false);
        }
    }

    public void FillInText(string infoText)
    {
        information.text = infoText;
    }
}