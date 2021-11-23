using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeodeticnaarECEF : MonoBehaviour
{
    private float N = 6399594;
    private float scale = 10000;
    [SerializeField] private float altitude;
    [SerializeField] private float latitude;
    [SerializeField] private float longitude;
    [SerializeField] private GameObject Placeholder;
    public void Converter()
    {
        var X = (N + altitude) * Mathf.Cos(latitude) * Mathf.Cos(longitude);
        var Y = 0;
        var Z = (N + altitude) * Mathf.Cos(latitude) * Mathf.Sin(longitude);
        
        Vector3 ConvertedXYZ = new Vector3(X / scale, Y / scale, Z / scale);
        Instantiate(Placeholder, ConvertedXYZ, Quaternion.identity);
    }
    public void Start()
    {
        Converter();
    }
}
