using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARCursor : MonoBehaviour
{
    [SerializeField]
    private GameObject childObjectCursor;
    /*
     *    [SerializeField]
     *    private GameObject objectToPlace;
     */
    [SerializeField]
    private ARRaycastManager arRaycastManager;

    private bool useCursor = true;

    public void Start()
    {
        childObjectCursor.SetActive(useCursor);
    }

    public void Update()
    {
        if (useCursor)
        {
            UpdateCursor();
        }
    }

    private void UpdateCursor()
    {
        Vector2 ScreenPosition = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(ScreenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;
        }
    }
}
