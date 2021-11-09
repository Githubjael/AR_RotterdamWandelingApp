using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class SetToCurrentCoords : MonoBehaviour
{
    [SerializeField]
    private float currentCoordslat;
    [SerializeField]
    private float currentCoordslon;

    private IEnumerator currentCoroutine;

    [SerializeField]
    private GameObject Observer;

    public void Start()
    {
        currentCoroutine = MoveObserver();
        if(currentCoroutine == null)
        {
            StartCoroutine(MoveObserver());
        }
    }
    private IEnumerator MoveObserver()
    {
        if (!Input.location.isEnabledByUser)
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        Input.location.Start();
        int maxWait = 5;
        if (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            Mathf.Round(maxWait--);
        }

        if (maxWait < 0)
        {
            Debug.Log("Timed Out!");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Camera Management Failed");
            yield break;
        }
        else
        {
            var ObserverCoords = GPSEncoder.GPSToUCS((float)Input.location.lastData.latitude, (float)Input.location.lastData.longitude);
            Observer.transform.Translate(ObserverCoords.x, 0, ObserverCoords.z);
        }

        Input.location.Stop();
    }
}
