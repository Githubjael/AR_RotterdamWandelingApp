using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class Gazing : MonoBehaviour
{
    [SerializeField]
    private GameObject Infopanel;
    [SerializeField]
    private Camera arCamera;
    [SerializeField]
    private ARRaycastManager arRaycastManager;
    [SerializeField]
    public TextMeshProUGUI dynamicText;

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public void Gaze()
    {


        foreach (Touch touch in Input.touches)
        {
            if(Input.touchCount > 0 && touch.phase == TouchPhase.Began)
            {
                if ()
                {

                }
            }
        }
    }
}
