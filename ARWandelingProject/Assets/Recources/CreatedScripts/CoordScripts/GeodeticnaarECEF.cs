using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeodeticnaarECEF : MonoBehaviour
{
    /// <summary>
    /// deze script moet geodectic coords naar ECEF(x,y,z) coords converteren.
    /// </summary>
    private float N = 6399594;
    private float scale = 38000;
    [SerializeField] private float altitude;
    [SerializeField] private float latitude;
    [SerializeField] private float longitude;
    [SerializeField] private GameObject Placeholder;
    public void Convert()
    {
        var X = (N + altitude) * Mathf.Cos(latitude) * Mathf.Cos(longitude);
        Debug.Log(X);
        var Y = 0;
        var Z = (N + altitude) * Mathf.Cos(latitude) * Mathf.Sin(longitude);
        Debug.Log(Z);
        
        Vector3 ConvertedXYZ = new Vector3(X, Y, Z);
        Instantiate(Placeholder, ConvertedXYZ, Quaternion.identity);
    }
    public void Start()
    {
        Convert();
    }
}