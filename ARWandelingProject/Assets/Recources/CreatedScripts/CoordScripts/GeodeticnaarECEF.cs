using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeodeticnaarECEF : MonoBehaviour
{
    private float N = 6399594;
    [SerializeField] private float altitude;
    [SerializeField] private float latitude;
    [SerializeField] private float longitude;
    public void Converter(float lat, float alt, float lon)
    {
        var X = (N + altitude) * Mathf.Cos(latitude) * Mathf.Cos(longitude);
        var Y = (N + altitude) * Mathf.Cos(latitude) * Mathf.Sin(longitude);
        var Z = 0;
        
        Vector3 ConvertedXYZ = new Vector3(X, Y, Z);
    }
}
