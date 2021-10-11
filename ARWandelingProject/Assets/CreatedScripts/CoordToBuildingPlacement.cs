using System;
using System.Collections.Generic;
using UnityEngine;

public class CoordToBuildingPlacement : MonoBehaviour
{
    public float longitude;
    public float latitude;

    public double R = 637100;

    public double AnchorpointA = 51.92442152092351;
    public double AnchorpointA1 = 4.477735165226141;

    public List<GameObject> Buildings;
#region Location1
    public double latLoc1 = 51.92442152092351;
    public double lonLoc1 = 4.477735165226141;
    #endregion

    public void Start()
    {
        GetGPSData();
    }

    public void Placement()
    {
        //Instantiate(Buildings[0], new Vector3(x, 0f, z), Quaternion.identity);
    }

    public void GetGPSData()
    {
        Input.location.Start();
        var currentGPSposition = Input.location.lastData;
        float z = latToZ(Input.location.lastData.latitude);
        float x = lonToX(Input.location.lastData.longitude);

        this.transform.position = new Vector3(x, 0f, z);
        Instantiate(Buildings[0], new Vector3(x, 0f, z), Quaternion.identity);
        PlaceLocation1();
    }

    float latToZ(double latitude)
    {
        latitude = (latitude - AnchorpointA) / 0.00001 * 00.12179047095976932582726898256213;
        double z = latitude;

        return (float)z;/**/
        /*double z = Math.Sin(latitude);
        return (float)z;*/
    }
    float lonToX(double longitude)
    {
        /**/longitude = (longitude - AnchorpointA1) / 0.00001 * 00.00728553580298947812081345114627;
        double x = longitude;

        return (float)x ;

        /*double x = R * Math.Cos(latitude) * Math.Cos(longitude);

        return (float)x;*/
    }
    #region Location1ConvertAnchor
    float lonToXLoc1Anchor(double longitude)
    {
        /**/
        longitude = (longitude - AnchorpointA1) / 0.00001 * 00.00728553580298947812081345114627;
        double x = longitude;

        return (float)x;

        /*double x = R * Math.Cos(latitude) * Math.Cos(longitude);

        return (float)x;*/
    }
    float latToZLoc1Anchor(double latitude)
    {
        latitude = (latitude - AnchorpointA) / 0.00001 * 00.12179047095976932582726898256213;
        double z = latitude;

        return (float)z;/**/
        /*double z = Math.Sin(latitude);
        return (float)z;*/
    }
    #endregion
    #region Location1Convert
    public void PlaceLocation1()
    {
        float z = latToZLoc1(Input.location.lastData.latitude);
        float x = lonToXLoc1(Input.location.lastData.longitude);
        Instantiate(Buildings[0], new Vector3( x, 0f, z), Quaternion.identity);
    }
    float lonToXLoc1(double lonLoc1)
    {
        /*longitude = (longitude - AnchorpointA1) / 0.00001 * 00.00728553580298947812081345114627;
        double x = longitude;

        return (float)x ;*/

        double x = R * Math.Cos(latLoc1) * Math.Cos(lonLoc1);

        return (float)x;
    }
    float latToZLoc1(double latLoc1)
    {
        /*latitude = (latitude - AnchorpointA) / 0.00001 * 00.12179047095976932582726898256213;
        double z = latitude;

        return (float)z;*/
        double z = Math.Sin(latLoc1);
        return (float)z;
    }
    #endregion
}