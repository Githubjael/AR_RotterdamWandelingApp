using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class OntvangInput : MonoBehaviour
{
    public Text LATLON;
    public void Start()
    {
        StartCoroutine(Receiver());
    }
    public IEnumerator Receiver()
    {
        //ask for permission if there is none, just in case.
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        Input.location.Start();
        int maxWait = 5;
        if( Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if(maxWait < 0)
        {
            yield break;
        }
        if(Input.location.status == LocationServiceStatus.Failed)
        {
            yield break;
        }
        else
        {
            string lat = Input.location.lastData.latitude.ToString();
            string lon = Input.location.lastData.longitude.ToString();
            LATLON.text = $"lat:{lat}, lon:{lon}";
        }
        Input.location.Stop();
    }
}
