using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLocCoordObjectPlacement : MonoBehaviour
{

    #region Anchorpoints
    public double Anchorpoint1lat = 51.92796883177615;
    public double Anchorpoint1lon = 4.4807745134267645;
    public double Anchorpoint2lat = 51.92705582077611;
    public double Anchorpoint2lon = 4.47990547771943;
    #endregion
    #region gameobjects
    [Tooltip("The list of building gameobjects to place in the scene")]
    public List<GameObject> Buildings;
    #endregion

    public void GPSData()
    {
        Input.location.Start();
        var gpsdata = Input.location.lastData;
        float z = LatToZ(Input.location.lastData.latitude);
        float x = LonToX(Input.location.lastData.longitude);

        Instantiate(Buildings[0], new Vector3(x ,0f ,z ), Quaternion.identity);
    }
    #region Converting1Anchor
    //This region is for converting Longitude and Latitude to unity's X and Y using 1 Anchorpoint.
    private float LonToX(double lon1)
    {
        lon1 = (lon1 - Anchorpoint1lon) / 0.000001 * 0.00728553580298947812081345114627;
        double x = lon1;
        return (float)x;
    }

    private float LatToZ(double lat1)
    {
        lat1 = (lat1 - Anchorpoint1lat) / 0.00001 * 0.12179047095976932582726898256213;
        double z = lat1;
        return (float)z;
    }
    #endregion
    #region Converting2Anchors

    #endregion
}

