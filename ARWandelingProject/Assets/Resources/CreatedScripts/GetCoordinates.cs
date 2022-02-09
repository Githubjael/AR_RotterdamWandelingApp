using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.Android;

public class GetCoordinates : MonoBehaviour
{
    public TextMeshProUGUI Coords;
    Coroutine getTheCoords;

    private void Start()
    {
        getTheCoords = StartCoroutine(GeoCoordinates());
    }
    
    IEnumerator GeoCoordinates()
    {
        //check if location service is enabled
        if (!Input.location.isEnabledByUser)
        {
            Coords.text = "Location is not enabled";
            yield break;
        }
        //ask for permission to use their location
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        Input.location.Start();
        int maxWait = 5;

        //initialize locationService
        if(Input.location.status == LocationServiceStatus.Initializing && maxWait < 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if(maxWait < 0)
        {
            Coords.text = "Something went wrong with the wait";
            yield break;
        }

        // in case it fails
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Coords.text = "Location Service failed";
            yield break;
        }
        else
        {
            InvokeRepeating("UpdateGPS", 0.5f, 1f);
        }

        yield return null;
    }
    private void UpdateGPS()
    {
        //relevant values for current geo position.
        float altitude = Input.location.lastData.altitude;
        float latitude = Input.location.lastData.latitude;
        float longitude = Input.location.lastData.longitude;
        //  dislpay values
        Coords.text = $"altitude:{altitude}, latitude:{latitude}, longitude:{longitude}";
    }
    
}
