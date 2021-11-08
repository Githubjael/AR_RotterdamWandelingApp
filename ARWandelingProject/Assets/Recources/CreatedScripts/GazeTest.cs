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

    public void Start()
    {
        Gaze();
    }
    public void Gaze()
    {
        if (Input.GetMouseButtonUp(0))
        {
            infoPrompt.SetActive(true);
            FillInText("Die on this hill.");
        }

    }

    public void FillInText(string infoText)
    {
        information.text = infoText;
    }
}