using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeodeticnaarECEF : MonoBehaviour
{
    /// <summary>
    /// deze script moet geodectic coords naar ECEF coords converteren
    /// </summary>
    private float N = 6399594;
    private float scale = 1800;
    [SerializeField] private float altitude;
    [SerializeField] private float latitude;
    [SerializeField] private float longitude;
    [SerializeField] private GameObject Placeholder;
    public void Converter()
    {
        var X = (N + altitude) * Mathf.Cos(latitude) * Mathf.Cos(longitude);
        Debug.Log(X);
        var Y = 0;
        var Z = (N + altitude) * Mathf.Cos(latitude) * Mathf.Sin(longitude);
        Debug.Log(Z);
        
        Vector3 ConvertedXYZ = new Vector3(X / scale, Y, Z / scale);
        Instantiate(Placeholder, ConvertedXYZ, Quaternion.identity);
    }
    public void Start()
    {
        Converter();
    }
}
