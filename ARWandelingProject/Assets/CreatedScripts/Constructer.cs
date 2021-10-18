using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Constructer
{

    public double AnchorPoint1lat;
    public double AnchorPoint1lon;
    public double latitude;
    public double longitude;
    public double scale;

    public Constructer(double AnchorPoint1lat, double AnchorPoint1lon, double latitude, double longitude, double scale)
    {

        this.AnchorPoint1lat = AnchorPoint1lat;
        this.AnchorPoint1lon = AnchorPoint1lon;
        this.latitude = latitude;
        this.longitude = longitude;
        this.scale = scale;

    }

}