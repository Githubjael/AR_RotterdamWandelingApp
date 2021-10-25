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

    [Tooltip("This list contains Gameobjects (currently filled with placeholders)")]
    [SerializeReference]
    public GameObject[] objectPlacement;
    //coords for the local origin for the GPSEncoder
    [SerializeReference]
    private double originlat = 51.924442317391886;
    [SerializeReference]
    private double originlon = 4.477769927599614;
    //not necesary anymore
    //public bool isUpdating;

    private Coroutine CurrentCoroutine;

    public TextMeshProUGUI Loc1Text;
    public TextMeshProUGUI CurrentCoordText;
    public TextMeshProUGUI IRLcoords;
    #endregion

    private void Awake()
    {
        objectPlacement = new GameObject[2];
    }

    void Start()
    {
        GPSEncoder.SetLocalOrigin(new Vector2((float)originlat,(float)originlon));
        
        CurrentCoroutine = StartCoroutine(ARGPSFunction());
        if (CurrentCoroutine != null)
        {
            StopCoroutine(CurrentCoroutine);
        }
    }

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
            double testlat = 51.92713599182974;
            double testlon = 4.480262115040381;

            Vector2 Testcoords = new Vector2((float)testlat, (float)testlon);
            Vector3 Coordplacement = GPSEncoder.GPSToUCS(Testcoords);
            Vector3 Currentloc = GPSEncoder.GPSToUCS((float)Input.location.lastData.latitude, (float)Input.location.lastData.longitude);
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

            Input.location.Stop();
            yield return null;
        }

    }

}
