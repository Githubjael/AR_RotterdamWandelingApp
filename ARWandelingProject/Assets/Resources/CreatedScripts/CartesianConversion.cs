using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartesianConversion : MonoBehaviour
{
    public int R = 6371 * 1000;
    /*public float latitude;
    public float longitude;*/
    Coords coords = new Coords();
    public Coords[] listOfCoords;
    public void Start()
    {
        for(int i = 0; i < listOfCoords.Length; i++)
        {
            print(listOfCoords[i].Locatie);
            print(Converter(listOfCoords[i].latitude, listOfCoords[i].longitude));
        }
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
        public int Locatie;
        public float latitude;
        public float longitude;
    }
}
