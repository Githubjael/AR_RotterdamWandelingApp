using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Android;
public class MenuGPS : MonoBehaviour
{
    //get the TextMeshProUGUI's from the canvas in the Menu Scene
    public TextMeshProUGUI GPS;
    public TextMeshProUGUI Lon;
    public TextMeshProUGUI Lat;
    public float Longitude;
    public float Latitude;

    public void Start()
    {
        StartCoroutine(LocationFunction());
    }

    private IEnumerator LocationFunction()
    {
        if (!Input.location.isEnabledByUser)
        {
            Permission.RequestUserPermission(Permission.CoarseLocation);
            //Save this foor apple build
            //Application.RequestUserAuthorization(UserAuthorization.WebCam);

            if (!Permission.HasUserAuthorizedPermission(Permission.CoarseLocation))
            {
                GPS.text += "User has not Authorized permisson.";
            }
            else
            {
                Input.location.Start();
                int maxWait = 5;
                while (Input.location.status == LocationServiceStatus.Initializing & maxWait > 0)
                {
                    yield return new WaitForSeconds(1);
                    maxWait--;
                }
                //if maxWait is somehow wrong
                if(maxWait <= 0)
                {
                    GPS.text += "Something went wrong with maxWait";
                }
                //if it somehow fails
                if(Input.location.status == LocationServiceStatus.Failed)
                {
                    GPS.text += "Something went wrong with Location function.";
                }

                //when everything works fill in lon and lat with the correct values
                Longitude = Input.location.lastData.longitude;
                Latitude = Input.location.lastData.latitude;

                Lon.text += $"{Longitude}";
                Lat.text += $"{Latitude}";

            }

            yield break;
        }
    }
}
