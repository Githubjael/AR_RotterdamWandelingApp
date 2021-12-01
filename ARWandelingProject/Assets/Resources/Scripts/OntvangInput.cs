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
        
    }
    public void Receiver()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        Input.location.Start();
        string lat = Input.location.lastData.latitude.ToString();
        string lon = Input.location.lastData.longitude.ToString();
        LATLON.text = $"lat:{lat}, lon:{lon}";
        Input.location.Stop();
    }
}
