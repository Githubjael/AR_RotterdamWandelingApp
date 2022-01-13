using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartesianConversion : MonoBehaviour
{
    public int R = 6371 * 1000;
    /*public float latitude;
    public float longitude;*/
    Coords coords = new Coords();
    public List<Coords> listOfCoords = new List<Coords>();
    public void Start()
    {
        print(Converter(coords.latitude, coords.longitude));
    }

    public Vector3 Converter(float latitude, float longitude)
    {
        float x = R * Mathf.Cos(latitude) * Mathf.Cos(longitude);
        float y = R * Mathf.Cos(latitude) * Mathf.Sin(longitude);
        float z = R * Mathf.Sin(latitude);

        return new Vector3(x, y, z);
    }

    [System.Serializable]
    public struct Coords
    {
        public string Locatie;
        public float latitude;
        public float longitude;
    }
}
