using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.XR.ARFoundation;

public class ManageCamera : MonoBehaviour
{
    [SerializeField]
    private ARCameraManager arCameraManager;

    [SerializeField]
    private float currentLat;
    [SerializeField]
    private float currentLon;

    [SerializeField]
    private IEnumerator calcAdjustment;

    private void Start()
    {
        calcAdjustment = Adjustment();
        ManageCameraTransform();
    }

    private IEnumerator Adjustment()
    {
        if (!Input.location.isEnabledByUser)
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        Input.location.Start();
        int maxWait = 5;
        if(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            Mathf.Round(maxWait--);
        }

        if(maxWait < 0)
        {
            Debug.Log("Timed Out!");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Camera Management Failed");
            yield break;
        }
        else
        {

        }

    }

    private void ManageCameraTransform()
    {

    }
}
