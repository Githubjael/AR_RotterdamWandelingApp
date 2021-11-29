using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;

public class CoordsTest : MonoBehaviour
{
    [SerializeField] GameObject Observer;
    [SerializeField] private float lat;
    [SerializeField] private float lon;

    public IEnumerator getCoords;

    public TextMeshProUGUI currentGeoCoords;
    public TextMeshProUGUI ucsCoords;

    public IEnumerator currentCoords()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        Input.location.Start();
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location is not Enabled.");
            yield break;
        }

        int maxWait = 10;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {
            print("Timed out.");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine location.");
            yield break;
        }
        else
        {
            lat = Input.location.lastData.latitude;
            currentGeoCoords.text = lat.ToString();
            lon = Input.location.lastData.longitude;
            currentGeoCoords.text += lon.ToString();

            Vector2 UCScoords = new Vector2(lat, lon);
            //Vector2 ucsCoords = new Vector2(Observer.transform.position.x, Observer.transform.position.y, Observer.transform);
            ucsCoords.text = UCScoords.ToString();
            //Observer.transform.position = GPSEncoder.GPSToUCS(lat, lon);
            //Vector3 translatedCoords = GPSEncoder.GPSToUCS(lat, lon);
            //Observer.transform.position = (translatedCoords);
        }
    }

    public void Start()
    {
        Observer = gameObject;
    }
    private void Update()
    {
        getCoords = currentCoords();
        if (getCoords != null)
        {
            StartCoroutine(getCoords);
        }
        else
        {
            StopCoroutine(getCoords);
        }
    }
}
