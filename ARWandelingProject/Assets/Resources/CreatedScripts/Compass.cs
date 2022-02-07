using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using TMPro;

public class Compass : MonoBehaviour
{
    public TextMeshProUGUI compassReadings;

    private void Start()
    {
        StartCoroutine(ReadCompass());
    }
    IEnumerator ReadCompass()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        else
        {
            compassReadings.text = "User has not Authorized permission.";
        }

        Input.location.Start();
        float heading = Input.compass.trueHeading;

        compassReadings.text = $"{heading}";

        yield return null;
    }
}
