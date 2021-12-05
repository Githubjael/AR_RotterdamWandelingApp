using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager arraycastmanagerorigin;
    private ARSessionOrigin arOrigin;
    public GameObject ObjectToplace;
    public GameObject placementindicator;
    public bool placementisvalid = false;
    public Pose placementpose;

    private void Awake()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
        arraycastmanagerorigin = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (placementisvalid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }
    }

    private void PlaceObject()
    {
        Instantiate(ObjectToplace, placementpose.position, placementpose.rotation);
    }

    private void UpdatePlacementIndicator()
    {
        if (placementisvalid)
        {
            placementindicator.SetActive(true);
            placementindicator.transform.SetPositionAndRotation(placementpose.position, placementpose.rotation);
        }
        else
        {
            placementindicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screencenter = Camera.current.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arraycastmanagerorigin.Raycast(screencenter, hits, TrackableType.Planes);
        placementisvalid = hits.Count > 0;

        if(placementisvalid)
        {
            placementpose = hits[0].pose;

            var camerafoward = Camera.current.transform.forward;
            var camerabearing = new Vector3(camerafoward.x, 0, camerafoward.z);
            placementpose.rotation = Quaternion.LookRotation(camerabearing);
        }
    }
}
