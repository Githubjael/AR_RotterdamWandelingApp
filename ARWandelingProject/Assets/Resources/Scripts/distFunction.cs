using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distFunction : MonoBehaviour
{
    [SerializeField] float tLon = (float)4.522115284114317;
    [SerializeField] float lon = (float)4.522812375416302;
    [SerializeField] float tLat = (float)51.85420688272829;
    [SerializeField] float lat = (float)51.85428582024129;

    [SerializeField] Text receivertext;

    private void Update()
    {
        function();
    }
    public void function()
    {
        float xx = dist(0, tLon, 0, lon), zz = dist(tLat, 0, lat, 0);
        Vector3 position = new Vector3(xx, 0, zz);
        position.Normalize();
        position = Quaternion.AngleAxis(Input.compass.trueHeading, Vector3.up) * position;
        float beta = Mathf.Acos(position.z) * Mathf.Rad2Deg;
        position = Quaternion.Euler(0, beta - Input.compass.trueHeading, 0) * position;
        transform.position = position;
        receivertext.text = transform.position.ToString();
    }
    //geo measurement voor algemeene gebruik
    public float dist(float lat1, float lon1, float lat2, float lon2)
    {
        var R = 6378.137;
        var dLat = (lat2 - lat1) * Mathf.PI / 180;
        var dLon = (lon2 - lon1) * Mathf.PI / 180;
        var a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) + Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
                Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);
        var c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        var d = R * c;
        return (float)(d * 1000);//meters
    }
}
