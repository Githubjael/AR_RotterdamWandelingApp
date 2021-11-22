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
    private void Start()
    {
        Coords((float)51.92782328054513, (float)4.480463377141008);
    }

    public void Coords(float lat, float lon)
    {
        latitude = lat;
        longitude = lon;
        Vector2 CoordsToTranslate = new Vector2(latitude, longitude);
        Vector3 result = GPSEncoder.GPSToUCS(CoordsToTranslate);
        for (var  i = 0; i < 2; i++)
        {
            Instantiate<GameObject>(Placeholders[i]);
            Placeholders[i].transform.Translate(result);
            Instantiate<GameObject>(Placeholders[i]);
            Placeholders[i].transform.position = result;
        }
    }

}
