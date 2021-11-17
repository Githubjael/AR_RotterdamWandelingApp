using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordToRealLocation : MonoBehaviour, CoordInterface<float>
{
    [SerializeField]
    public float latitude;
    [SerializeField]
    public float longitude;

    [SerializeField]
    public List<GameObject> Placeholders = new List<GameObject>();
    void CoordInterface<float>.Coords(float lat, float lon)
    {
        latitude = lat;
        longitude = lon;
        Vector2 CoordsToTranslate = new Vector2(latitude, longitude);
        Vector3 result = GPSEncoder.GPSToUCS(CoordsToTranslate);
        for(var i = 0; i < 3; i++)
        {

        }
    }
    /*  
    public void Coords(float lat, float lon)
    {
        latitude = lat;
        longitude = lon;
        Vector2 CoordsToTranslate = new Vector2(latitude, longitude);
        Vector3 result = GPSEncoder.GPSToUCS(CoordsToTranslate);

    }
    */
}
