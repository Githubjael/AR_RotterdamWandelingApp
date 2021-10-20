using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using TMPro;
public class TestEncoderUse : MonoBehaviour
{

    public static TestEncoderUse instance;
    public bool IsUpdating;
    public TextMeshProUGUI Status;
    public TextMeshProUGUI Coords;

    public void Awake()
    {
        instance = this; 
    }

    public void Start()
    {
        GetGPSEncoder();

    }

    public void Update()
    {
        if (!IsUpdating)
        {
            StartCoroutine(GetGPS());
            IsUpdating = !IsUpdating;
        }
    }

    public void GetGPSEncoder()
    {
        double latitude = 51.923460;
        double longitude = 4.481160;
        float lat = Convert.ToSingle(latitude);
        float lon = Convert.ToSingle(longitude);

        GPSEncoder.GPSToUCS(new Vector2(lat, lon));
    }

    #region IEnumerator GetGPS()
    private IEnumerator GetGPS()
    {

        int maxWait = 10;
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation) || !Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
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

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            //Status.text = "Initializing...";
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        //if location service doesn't initialize n 20 secs
        if (maxWait > 0)
        {
            Status.text = "Timed Out!";
            yield break;
        }

        //Connection failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Status.text = "Unable to determine device location.";
            yield break;
        }
        else
        {
            Status.text = $"Latitude: {Input.location.lastData.latitude}" + " " + $"Longitude: {Input.location.lastData.longitude}";
        }

        IsUpdating = !IsUpdating;
        Input.location.Stop();

    }
    #endregion

}


