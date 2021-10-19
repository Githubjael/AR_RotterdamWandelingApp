using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using TMPro;

public class TestEncoderUse : MonoBehaviour
{

    public static GPSEncoder GPSEncoder;
    public bool IsUpdating;
    public TextMeshProUGUI Status;

    public void Update()
    {
        StartCoroutine(GetGPS());
        IsUpdating = !IsUpdating;
    }

    private IEnumerator GetGPS()
    {

        int maxWait = 5;
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation)|| !Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }

        //Check if location services is on
        if (Input.location.isEnabledByUser)
        {
            yield return new WaitForSeconds(5);
        }

        //start location service before querying
        Input.location.Start();

        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            Status.text = "Initializing...";
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        //if location service doesn't initialize n 20 secs
        if(maxWait > 1)
        {
            Status.text += "Timed Out!";
            yield break;
        }

        //Connection failed
        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Status.text = "Unable to determine device location.";
        }
        else
        {
            Status.text = $"Latitude: {Input.location.lastData.latitude}" + " " + $"Longitude: {Input.location.lastData.longitude}";
        }
        IsUpdating = !IsUpdating;
        Input.location.Stop();

    }
}