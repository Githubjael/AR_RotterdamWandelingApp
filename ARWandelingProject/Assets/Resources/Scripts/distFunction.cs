using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distFunction : MonoBehaviour
{
    [SerializeField] float tLon = (float)0;
    [SerializeField] float lon = (float)0;
    [SerializeField] float tLat = (float)0;
    [SerializeField] float lat = (float)0;

    [SerializeField] Text receivertext;

    public IEnumerator coroutine;
    private void Update()
    {
        coroutine = function();
        if(coroutine != null)
        {
            StartCoroutine(function());
        }
    }
    public IEnumerator function()
    {
        Input.location.Start();
        int maxWait = 5;
        if(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 0)
        {
            receivertext.text = "maxWait has failed.";
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            receivertext.text = $"{LocationServiceStatus.Failed.ToString()}";
        }
        else
        {
            tLon = Input.location.lastData.longitude;
            tLat = Input.location.lastData.latitude;
            float xx = dist(0, tLon, 0, lon), zz = dist(tLat, 0, lat, 0);
            Vector3 position = new Vector3(xx, 0, zz);
            position.Normalize();
            position = Quaternion.AngleAxis(Input.compass.trueHeading, Vector3.up) * position;
            float beta = Mathf.Acos(position.z) * Mathf.Rad2Deg;
            position = Quaternion.Euler(0, beta - Input.compass.trueHeading, 0) * position;
            transform.position = position;
            receivertext.text = transform.position.ToString();
        }
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
