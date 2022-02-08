using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Android;

public class GetCoordinates : MonoBehaviour
{
    public TextMeshProUGUI coords;
    Coroutine getTheCoords;

    private void Start()
    {
        coords = GetComponent<TextMeshProUGUI>();
        getTheCoords = StartCoroutine(GeoCoordinates());
    }
    
    IEnumerator GeoCoordinates()
    {
        //ask for permission if non is given
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        yield return null;
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }
        //start location service
        Input.location.Start();
        yield return null;
        int maxWait = 5;

        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
        }
        yield return null;
        if (maxWait < 0)
        {
            yield break;
        }
        yield return null;
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;
        }
        else
        {
            InvokeRepeating("UpdateGPS", 5f, 1f);
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
        coords.text = $"altitude:{altitude}, latitude:{latitude}, longitude:{longitude}";
    }
    
}
