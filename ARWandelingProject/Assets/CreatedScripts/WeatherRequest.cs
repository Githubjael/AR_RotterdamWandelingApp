using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WeatherRequest : MonoBehaviour
{
    private string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=-33.8670522,151.1957362&radius=500&types=food&name=harbour&key=AIzaSyAueLH6XEvQUexoYz83mh7ZXbe1FEPL7JQ";

    Text Places;

    public void GetWeather()
    {
        StartCoroutine(MakeWeatherRequest());
    }

    [System.Obsolete]
    IEnumerator MakeWeatherRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if(request.isNetworkError && !request.isHttpError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            var weather = JsonConvert.DeserializeObject<WeatherResponse>(request.downloadHandler.text);

            var t = weather;
        }
    }
}
