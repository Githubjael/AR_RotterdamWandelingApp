using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
public class MenuGPS : MonoBehaviour
{
    //1 niet nodig voor nu
    //public static MenuGPS Instance { get; set; }

    //get the TextMeshProUGUI's from the canvas in the Menu Scene
    public TextMeshProUGUI GPS;
    public TextMeshProUGUI Lon;
    public TextMeshProUGUI Lat;
    public float Longitude;
    public float Latitude;

    public void Start()
    {
        //1 inclusief dit
        /*Instance = this;*/
        DontDestroyOnLoad(gameObject);
        StartCoroutine(LocationFunction());
    }

    private IEnumerator LocationFunction()
    {
        Permission.RequestUserPermission(Permission.FineLocation);
        if (!Input.location.isEnabledByUser || !Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            GPS.text += "Location service has not been enabled.";
            yield break;
        }

        Input.location.Start();
        int maxWait = 5;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if( maxWait <= 0)
        {
            GPS.text += "Timed Out.";
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            GPS.text += "Unable to Determine Device Location.";
            yield break;
        }

        GPS.text += "Running";
        Longitude = Input.location.lastData.longitude;
        Latitude = Input.location.lastData.latitude;
        Lon.text += $"{Longitude}";
        Lat.text += $"{Latitude}";

    }
}
