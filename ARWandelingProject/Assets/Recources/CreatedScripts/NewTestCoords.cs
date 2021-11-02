using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Android;
using UnityEngine;
using TMPro;

public class NewTestCoords : MonoBehaviour
{
    #region PlaceholderTitle
    [Tooltip("This list contains Gameobjects (currently filled with placeholders)")]
    public List<GameObject> Objectplacement;

    //coords for the local origin for the GPSEncoder
    [SerializeField]
    private float originPointLat = (float)51.92720804188213;
    [SerializeField]
    private float originPointLon = (float)4.480268620814825;

    private IEnumerator CurrentCoroutine;

    public TextMeshProUGUI Loc1Text;
    public TextMeshProUGUI CurrentCoordText;
    public TextMeshProUGUI IRLcoords;
    #endregion
    private void Start()
    {
        SetOrigin();

        CurrentCoroutine = ARGPSFunction();
        if(CurrentCoroutine != null)
            StartCoroutine(CurrentCoroutine);
        else
            StopCoroutine(CurrentCoroutine);
    }
    private void SetOrigin()
    {
        Vector2 coords = new Vector2(originPointLat, originPointLon);
        GPSEncoder.SetLocalOrigin(coords);
    }
    /*
     *     private float LatToZ(float originlat, float originlon)
     *     {
     *     z = GPSEncoder.GPSToUCS(originlat, originlon).z;
     *     return (float) z;
     *     }
     *     private float LontoX(float originlon, float originlat)
     *     {
     *     x = GPSEncoder.GPSToUCS(originlat, originlon);
     *     return (float) x;
     *     }
     */

    /*
        * double LatToZ = Input.location.lastData.Latitude;
        * double LonToX = Input.location.lastData.Longitude;
        * GPSEncoder.SetLocalOrigin(new Vector2((float)LatToZ,(float)LonToX));
        */
    //GPSEncoder.SetLocalOrigin(new Vector2((float)originlat,(float)originlon));
    //Debug.Log($"lat:{originlat} lon: {originlon}");


    void Update()
    {

    }
    
    private IEnumerator ARGPSFunction()
    {

        if (!Input.location.isEnabledByUser)
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        Input.location.Start();
        int maxWait = 5;

        if(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSecondsRealtime(1);
            Mathf.Round(maxWait--);
        }

        if (maxWait < 0 )
        {
            Loc1Text.text = "Timed out!";
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Loc1Text.text = "I cannot determine device Location!";
            yield break;
        }
        else
        {

            #region TestCubePlacement
            //double testlat = 51.92713599182974;
            //double testlon = 4.480262115040381;

            //Vector2 Testcoords = new Vector2((float)testlat, (float)testlon);
            //Vector3 Coordplacement = GPSEncoder.GPSToUCS(Testcoords);
            //Vector3 Currentloc = GPSEncoder.GPSToUCS((float)Input.location.lastData.latitude, (float)Input.location.lastData.longitude);
            #endregion
            #region location1Calc
            double latLoc1 = 51.923460;
            double lonLoc1 = 4.481160;

            Vector2 Loc1Coords = new Vector2((float)latLoc1, (float)lonLoc1);

            string textCoordsLoc1 = $"{GPSEncoder.GPSToUCS(Loc1Coords)}";
            Loc1Text.text = "Loc1 (in game): " + textCoordsLoc1;
            #endregion

            CurrentCoordText.text = $"In game: {GPSEncoder.GPSToUCS((float)Input.location.lastData.latitude, (float)Input.location.lastData.longitude)}";
            IRLcoords.text = $"Latitude: {Input.location.lastData.latitude} Longitude: {Input.location.lastData.longitude}";

            StartCoroutine(SpawnObjects());

            Input.location.Stop();
            //yield return null;
        }

    }

    private IEnumerator SpawnObjects()
    {
        float testlat = (float)51.9271839435353;
        float testlon = (float)4.4802625771657665;

        float currentlat = (float)51.927796816633716;
        float currentlon = (float)4.4804311906327285;

        Vector2 testcurrentcoord = new Vector2( currentlat, currentlon);
        Vector2 testCoords = new Vector2( testlat, testlon);

        Vector3 testcurrentTranslation = GPSEncoder.GPSToUCS(testcurrentcoord);
        Vector3 testTranslation = GPSEncoder.GPSToUCS(testCoords);

        do
        {
            for (var i = 0; i < 3; i++)
            {
                Instantiate(Objectplacement[i] as GameObject);
                Objectplacement[i].transform.position = testcurrentTranslation;
                Instantiate(Objectplacement[i] as GameObject);
                Objectplacement[i].transform.position = testTranslation + new Vector3( 1 + i, 0, 2);

                //Instantiate(Resources.Load("CreatedPrefabs/Placeholder") as GameObject, testTranslation, Quaternion.identity);
                Debug.Log("Objects have been spawned.");
            }
        }
        while (SpawnObjects() == null);

        yield return new WaitForEndOfFrame();
    }
}
