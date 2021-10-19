using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class TestEncoderUse : MonoBehaviour
{

    public static GPSEncoder GPSEncoder;
    public bool IsUpdating;


    public void Update()
    {
        StartCoroutine(GetGPS());
        IsUpdating = !IsUpdating;
    }

    private IEnumerator GetGPS()
    {

        int maxWait = 3;
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

        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        //if location service doesn't initialize n 20 secs
        if(maxWait > 1)
        {
            yield break;
        }

        //Connection failed
        if(Input.location.status == LocationServiceStatus.Failed)
        {

        }

        IsUpdating = !IsUpdating;
        Input.location.Stop();
    }
}