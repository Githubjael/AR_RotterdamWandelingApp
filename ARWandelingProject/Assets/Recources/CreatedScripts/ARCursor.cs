using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{
    [SerializeField]
    private GameObject childObjectCursor;
    [SerializeField]
    private GameObject objectToPlace;
    [SerializeField]
    private ARRaycastManager arRaycastManager;
}
