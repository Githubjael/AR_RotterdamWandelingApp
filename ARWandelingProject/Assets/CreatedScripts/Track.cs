using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using TMPro;
[RequireComponent(typeof(ARRaycastManager))]
public class Track : MonoBehaviour
{
    private ARRaycastManager aRRaycastManager;

    [SerializeField]
    public GameObject Placement;

    public TextMeshProUGUI trackableType;
    void Update()
    {
        
    }
}
