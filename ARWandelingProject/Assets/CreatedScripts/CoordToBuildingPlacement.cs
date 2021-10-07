using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordToBuildingPlacement : MonoBehaviour
{
    public float longitude;
    public float latitude;

    public double AnchorpointA = 51.92442152092351;
    public double AnchorpointA1 = 4.477735165226141;

    public List<GameObject> Buildings;

    public void Start()
    {
        GetGPSData();
    }
    public void GetGPSData()
    {
        var currentGPSposition = Input.location.lastData;
        float z = latToZ(Input.location.lastData.latitude);
        float x = lonToX(Input.location.lastData.longitude);

        this.transform.position = new Vector3(x, 0f, z);

    }

    float latToZ(double latitude)
    {
        latitude = (latitude - AnchorpointA) / 0.00001 * 00.12179047095976932582726898256213;
        double z = latitude;

        return (float)z;
    }
    float lonToX(double longitude)
    {
        longitude = (longitude - AnchorpointA1) / 0.00001 * 00.00728553580298947812081345114627;
        double x = longitude;

        return (float)x ;
    }

}