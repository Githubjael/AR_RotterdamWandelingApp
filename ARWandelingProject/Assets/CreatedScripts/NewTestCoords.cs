using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Android;
using UnityEngine;
using TMPro;

public class NewTestCoords : MonoBehaviour
{
    #region PlaceholderTitle
    public List<GameObject> ObjectPlacement;
    [SerializeReference]
    private Vector2 LocalOrigin = new Vector2((float)51.92440614616623, (float)4.477705312843138);

    public bool isUpdating;

    public TextMeshProUGUI Loc1Text;
    public TextMeshProUGUI CurrentCoordText;
    #endregion

    private void Awake()
    {
        GPSEncoder.SetLocalOrigin(LocalOrigin);
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        //if (isUpdating){}
        StartCoroutine(ARGPSFunction());
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
            yield return new WaitForSeconds(1);
            Mathf.Round(maxWait--);
        }

        if (maxWait < 0 )
        {
            Loc1Text.text = "Timed out!";
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Loc1Text.text = "Cannot determine device Location";
            yield break;
        }
        else
        {
            #region location1Calc
            double latLoc1 = 51.923460;
            double lonLoc1 = 4.481160;
            Vector2 Loc1Coords = new Vector2((float)latLoc1, (float)lonLoc1);
            string textCoordsLoc1 = GPSEncoder.GPSToUCS(Loc1Coords).ToString();
            Loc1Text.text = textCoordsLoc1;
            #endregion
            CurrentCoordText.text = $"Latitude: {Input.location.lastData.latitude} Longitude: {Input.location.lastData.longitude}";
            Input.location.Stop();
            //isUpdating = !isUpdating;
        }

    }

}
