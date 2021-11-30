using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Android;

public class CoordsTest : MonoBehaviour
{
    /// <summary>
    /// Ik ben van plan om met deze script om de coords van echte locaties te converteren naar ucs.
    /// en de gebouwen op die ucs coords te plaatsen.
    /// </summary>
    [SerializeField] GameObject Observer;
    [SerializeField] private float lat;
    [SerializeField] private float lon;

    public IEnumerator getCoords;

    public TextMeshProUGUI status;
    public TextMeshProUGUI currentGeoCoords;
    public TextMeshProUGUI ucsCoörds;

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

        int maxWait = 5;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 0)
        {
            Debug.Log("Timed out.");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine location.");
            yield break;
        }
        else
        {
            lat = Input.location.lastData.latitude;
            lon = Input.location.lastData.longitude;
            currentGeoCoords.text = $"Lat:{lat},Lon:{lon}";

            //ik hou deze dingen om te zien als er later een gebruik ervoor is.
            //Vector2 UCScoords = new Vector2(lat, lon);
            //Vector2 ucsCoords = new Vector2(Observer.transform.position.x, Observer.transform.position.y, Observer.transform);
            //ucsCoords.text = UCScoords.ToString();
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
