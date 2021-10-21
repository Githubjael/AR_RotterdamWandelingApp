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

    public GameObject Placeholder;

    public TextMeshProUGUI Status;
    public TextMeshProUGUI Coords;
    public TextMeshProUGUI CurrentCoordsIRL;

    public List<GameObject> BuildingsToPlace;
    
    public void Awake()
    {
        instance = this; 
    }

    public void Start()
    {
        //Set LocalOrigin to lat: 51.9254786, lon: 4.4786903,17
        GPSEncoder.SetLocalOrigin(new Vector2((float)51.9254786, (float)4.478690317));
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
        #region Lat&Lon Location1
        double latitude = 51.92766449684264;
        double longitude = 4.480420461816436;
        
        float lat = Convert.ToSingle(latitude);
        float lon = Convert.ToSingle(longitude);
        #endregion

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

        while(Input.location.status == LocationServiceStatus.Initializing && Maxwait > 0)
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
            CurrentCoordsIRL.text = "Unable to determine device location";
            yield break;
        }
        else
        {
            //pointless
            /*double irlLatitude = Input.location.lastData.latitude;
            double irlLongitude = Input.location.lastData.longitude;*/

            Vector2 irlcoords = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
            //turn it into a vector3
            Vector3 placementcoords = GPSEncoder.GPSToUCS(irlcoords);
            //Instantiate a placeholder at current location to test; this one failed
            Instantiate(BuildingsToPlace[0], placementcoords, Quaternion.identity);

            //Put the placholder prfab already in the scene at the determined coordinates
            Placeholder.transform.position = GPSEncoder.GPSToUCS(irlcoords);

            //Display results on screen
            CurrentCoordsIRL.text = $"{GPSEncoder.GPSToUCS(irlcoords)}";
        }
        
        Vector3 coordinates = GPSEncoder.GPSToUCS(new Vector2(lat, lon));

        Coords.text = $"{coordinates}";

        var i = 0;
        while (i < 4)
        {
            Instantiate(BuildingsToPlace[0], coordinates, Quaternion.identity);
            i++;
        }

        //Doesn't work
        /*string latcoord = Input.location.lastData.latitude.ToString();
        string loncoord = Input.location.lastData.longitude.ToString();
        CurrentCoord.text = $"{CurrenCoordtPosition}" + $"{latcoord}" + $"{loncoord}";*/
        
        IsUpdating = !IsUpdating;
        Input.location.Stop();

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


