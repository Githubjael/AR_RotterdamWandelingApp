using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordsTest : MonoBehaviour
{
    [SerializeField] private float lat;
    [SerializeField] private float lon;

    [SerializeField] public List<GameObject> Placeholders = new List<GameObject>();

    private void Start()
    {
        var local = new Vector2(lat, lon);
        GPSEncoder.SetLocalOrigin(local);
    }
    private void Update()
    {
        Vector3 unityLocal = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        var local = GPSEncoder.USCToGPS(unityLocal);
        string localCoords = local.ToString();
        //Debug.Log(localCoords);
        //Debug.Log($"{local}");
    }
}
