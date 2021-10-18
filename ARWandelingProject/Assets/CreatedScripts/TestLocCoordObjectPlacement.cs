using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLocCoordObjectPlacement : MonoBehaviour
{

    #region Anchorpoints
    //the Longitude and Latitude of 2 Anchorpoints.
    public double Anchorpoint1lat = 51.92796883177615;
    public double Anchorpoint1lon = 4.4807745134267645;
    public double Anchorpoint2lat = 51.92705582077611;
    public double Anchorpoint2lon = 4.47990547771943;
    #endregion
    #region gameobjects
    //a list of building gameobjects to place in the scene.
    [Tooltip("The list of building gameobjects to place in the scene")]
    public List<GameObject> Buildings;
    #endregion
    #region Offset
    //this list is supposed to contain values that offset the placement of the building gameobjects.
    [Tooltip("The list of offset floats for placing building gameobjects")]
    public List<float> Offset;
    #endregion
    #region GPSData
    public void GPSData()
    {

        Input.location.Start();
        var gpsdata = Input.location.lastData;
        float z = LatToZ(Input.location.lastData.latitude);
        float x = LonToX(Input.location.lastData.longitude);
        Instantiate(Buildings[0], new Vector3(x, 0f, z), Quaternion.identity);
        z = LatsToZ(Input.location.lastData.latitude, Input.location.lastData.latitude);
        x = LonsToX(Input.location.lastData.latitude, Input.location.lastData.longitude);
        Instantiate(Buildings[0], new Vector3(x, 0f - 1, z + Offset[0]), Quaternion.identity);
        Instantiate(Buildings[0], new Vector3(x + Offset[0], 0f - 1, z + Offset[0]), Quaternion.identity);

    }
    #endregion
    private void Start()
    {
        GPSData();
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
    private float LatsToZ(double latitude1, double latitude2)
    {
        latitude1 = (latitude1 - Anchorpoint1lat) / 0.00001 * 0.12179047095976932582726898256213;
        latitude2 = (latitude2 - Anchorpoint2lat) / 0.00001 * 0.12179047095976932582726898256213;
        double z = latitude1 - latitude2;
        return (float)z;
    }
    private float LonsToX(double longitude1, double longitude2)
    {
        longitude1 = (longitude1 - Anchorpoint1lon) / 0.000001 * 0.00728553580298947812081345114627;
        longitude2 = (longitude2 - Anchorpoint2lon) / 0.000001 * 0.00728553580298947812081345114627;
        double x = longitude1 - longitude2;
        return (float)x;
    }
    #endregion

    #region method2
    public class Lanlon
    {
        private static float convertCoordinates(float oldvalue, float oldMin, float oldMax, float newMin, float newMax)
        {
            float oldRange = oldMax - oldMax;
            float newRange = newMax - newMin;
            float returnValue = (((oldvalue - oldMin) * newRange) / oldRange) + newMin;
            Debug.Log(returnValue);
            return returnValue;
        }

        public static Vector3 GetUnityPosition(Vector2 latlonPosition, Vector2 northwestlatlon, Vector2 southeastlatlon, Vector3 northwestUnity, Vector3 southeastUnity)
        {
            if (southeastlatlon.y < northwestlatlon.y)
            {
                southeastlatlon = new Vector2(southeastlatlon.x, southeastlatlon.y + 360f);

                if (latlonPosition.y < 0f)
                {
                    latlonPosition = new Vector2(latlonPosition.x, latlonPosition.y + 360f);
                }
            }

            float newUnityLat = convertCoordinates(latlonPosition.x, southeastlatlon.x, northwestlatlon.x, southeastUnity.z, northwestUnity.z);
            float newUnityLon = convertCoordinates(latlonPosition.y, southeastlatlon.y, northwestlatlon.y, southeastUnity.x, northwestUnity.x);
            Vector3 UnityWorldposition = new Vector3(newUnityLon, 200f, newUnityLat);
            Debug.Log(UnityWorldposition);
            return UnityWorldposition;
            
        }

        public static Vector2 GetLatLonPosition(Vector3 unityPosition, Vector2 northWestLatLon, Vector2 southEastLatLon, Vector3 northWestUnity, Vector3 southEastUnity)
        {
            bool antimeridian = false;

            if (southEastLatLon.y < northWestLatLon.y)
            {
                antimeridian = true;
                southEastLatLon = new Vector2(southEastLatLon.x, southEastLatLon.y + 360f);
            }

            float newLat = convertCoordinates(unityPosition.z, southEastUnity.z, northWestUnity.z, southEastLatLon.x, northWestLatLon.x);
            float newLon = convertCoordinates(unityPosition.x, southEastUnity.z, northWestUnity.x, southEastLatLon.y, northWestLatLon.y);

            if (antimeridian)
            {
                if (newLon > 180f)
                {
                    newLon = newLon - 360f;
                }
            }

            Vector2 latLonPosition = new Vector2(newLat, newLon);
            Debug.Log(latLonPosition);
            return latLonPosition;
        }

    } 
    #endregion

}
