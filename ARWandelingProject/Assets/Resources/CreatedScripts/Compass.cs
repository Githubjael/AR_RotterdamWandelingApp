using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.Android;
using UnityEngine.XR.ARFoundation;

public class Compass : MonoBehaviour
{
    public TextMeshProUGUI compassReadings;
    public ARSessionOrigin arSessionOrigin;
    Coroutine readTheCompass;

    private void Start()
    {
        readTheCompass = StartCoroutine(ReadCompass());
        arSessionOrigin = FindObjectOfType<ARSessionOrigin>();
    }
    
    /*private void OnGUI()
    {
        GUILayout.Label($"compass:" + Input.compass.rawVector.ToString());
    }*/

    IEnumerator ReadCompass()
    {
        //if there is no permission, ask.
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        else
        {
            compassReadings.text = "User has not Authorized permission.";
        }

        //if location service is disabled, then stop.
        if (!Input.location.isEnabledByUser)
        {
            yield break;
        }

        //has to be enabled for the compass to work.
        Input.compass.enabled = true;
        
        //start the location service.
        Input.location.Start();
        //skip a frame
        yield return null;
        int maxWait = 5;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) 
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
            InvokeRepeating("UpdateCompass", 1f, 1f);
        }
        yield return null;
    }

    private void UpdateCompass()
    {
        compassReadings.text = $"Magnetic: {Input.compass.magneticHeading}";
        compassReadings.text += $"RawVector: {Input.compass.rawVector}";
        compassReadings.text += $"TrueHeading: {Input.compass.trueHeading}";
    }
}
