using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour
{

    #region Objects
    public GameObject[] BuildingsArray = new GameObject[9];
    public Constructer[] constructors = new Constructer[2];
    public double[] Lats = new double[4] {0,0,0,0};
    public double[] Lons = new double[4] {0,0,0,0};
    #endregion

    public void Start()
    {
        
        constructors[0] = new Constructer(51.92796883177615, 4.4807745134267645, 51.92442152092351, 4.477735165226141, 10000);
        Calculate();
    }

    #region Calculate Function, lonToX + latToZ
    public void Calculate()
    {
        float z = latToZ(Input.location.lastData.latitude);
        float x = lonToX(Input.location.lastData.longitude);
        Instantiate(BuildingsArray[0], new Vector3( x, 0f, z), Quaternion.identity);
    }

    float latToZ(double latitude)
    {
        latitude = (constructors[0].latitude - constructors[0].AnchorPoint1lat) / 0.00001 * 0.12179047095976932582726898256213;
        double x = latitude;
        return (float)x;
    }

    float lonToX(double longitude)
    {
        longitude = (constructors[0].longitude - constructors[0].AnchorPoint1lon) / 0.000001 * 0.00728553580298947812081345114627;
        double z = longitude;
        return (float)z;
    }
    #endregion

}
