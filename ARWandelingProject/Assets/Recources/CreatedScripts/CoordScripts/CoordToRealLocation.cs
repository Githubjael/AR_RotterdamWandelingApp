using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordToRealLocation : MonoBehaviour, CoordInterface<float>
{
    [SerializeField]
    public float latitude;
    [SerializeField]
    public float longitude;

    [SerializeField]public List<GameObject> Placeholders = new List<GameObject>();
/*    void CoordInterface<float>.Coords(float lat, float lon)
    {
        latitude = lat;
        longitude = lon;
        Vector2 CoordsToTranslate = new Vector2(latitude, longitude);
        Vector3 result = GPSEncoder.GPSToUCS(CoordsToTranslate);
        Debug.Log(result);
    }*/
    private void Update()
    {
        
    }

    public void Coords(float lat, float lon)
    {
        latitude = lat;
        longitude = lon;
        Vector2 CoordsToTranslate = new Vector2(latitude, longitude);
        Vector3 result = GPSEncoder.GPSToUCS(CoordsToTranslate);
        for (var  i = 0; i < 3; i++)
        {
            Instantiate<GameObject>(Placeholders[i]);
            Placeholders[i].transform.Translate(result);
            Instantiate<GameObject>(Placeholders[i]);
            Placeholders[i].transform.position = result;
        }
    }

}
