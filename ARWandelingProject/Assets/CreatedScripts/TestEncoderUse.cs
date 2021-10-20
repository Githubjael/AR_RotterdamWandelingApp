using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using TMPro;
public class TestEncoderUse : MonoBehaviour
{

    public static TestEncoderUse instance;
    public GameObject CurrentARCameraCoordPosition;
    public bool IsUpdating;
    public TextMeshProUGUI Status;
    public TextMeshProUGUI Coords;
    public TextMeshProUGUI CurrentCoordingame;
    public TextMeshProUGUI CurrentCoordsIRL;
    public List<GameObject> BuildingsToPlace;
    
    public void Awake()
    {
        instance = this; 
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        if (!IsUpdating)
        {
            StartCoroutine(GetGPSEncoder());
            StartCoroutine(GetGPS());
            IsUpdating = !IsUpdating;
        }
    }

    #region GetGPSEncoder
    public IEnumerator GetGPSEncoder()
    {
        int Maxwait = 10;

        double latitude = 51.92766449684264;
        double longitude = 4.480420461816436;

        float lat = Convert.ToSingle(latitude);
        float lon = Convert.ToSingle(longitude);

        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation) || !Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }

        if (Input.location.isEnabledByUser)
        {
            yield return new WaitForSeconds(5);
        }
        else
        {
            CurrentCoordsIRL.text = "Location is not enabled!";
            yield break;
        }

        Input.location.Start();

        while(Input.location.status == LocationServiceStatus.Initializing && Maxwait >= 0)
        {
            yield return new WaitForSeconds(1);
            Maxwait--;
        }

        if(Maxwait < 0)
        {
            CurrentCoordsIRL.text = "Timed Out!";
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            CurrentCoordsIRL.text = "Unable to determin device location";
            yield break;
        }
        else
        {
            double irlLatitude = Input.location.lastData.latitude;
            double irlLongitude = Input.location.lastData.longitude;
            Vector2 irlcoords = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
            CurrentCoordsIRL.text = GPSEncoder.GPSToUCS(irlcoords).ToString();
            CurrentCoordsIRL.text += GPSEncoder.USCToGPS(new Vector3( 0, 0, 0)).ToString();
        }

        Vector3 irlCoords = new Vector3(Input.location.lastData.latitude, 0, Input.location.lastData.longitude);
        Vector3 currentcoordposition = GPSEncoder.USCToGPS(CurrentARCameraCoordPosition.transform.position);
        
        Vector3 coordinates = GPSEncoder.GPSToUCS(new Vector2(lat, lon));

        CurrentCoordingame.text = $"{currentcoordposition}";

        Coords.text = coordinates.ToString();

        var i = 0;
        while (i < 4)
        {
            Instantiate(BuildingsToPlace[0], irlCoords, Quaternion.identity);
            Instantiate(BuildingsToPlace[0], coordinates + new Vector3(Mathf.Round(UnityEngine.Random.Range(1, 5)) , 0, Mathf.Round(UnityEngine.Random.Range(1, 5))), Quaternion.identity);
            i++;
        }

        //Doesn't work
        /*string latcoord = Input.location.lastData.latitude.ToString();
        string loncoord = Input.location.lastData.longitude.ToString();
        CurrentCoord.text = $"{CurrenCoordtPosition}" + $"{latcoord}" + $"{loncoord}";*/
        Input.location.Stop();
        IsUpdating = !IsUpdating;

    }
    #endregion

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
        if (maxWait < 0)
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
            //CurrentCoord.text = $"Latitude: {Input.location.lastData.latitude}" + " " + $"Longitude: {Input.location.lastData.longitude}";
        }

        IsUpdating = !IsUpdating;
        Input.location.Stop();

    }
    #endregion

}


