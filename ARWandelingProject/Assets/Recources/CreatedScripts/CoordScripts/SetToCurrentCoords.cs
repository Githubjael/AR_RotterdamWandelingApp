using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.XR.ARFoundation;

public class SetToCurrentCoords : MonoBehaviour
{
    /// <summary>
    /// dit was ook een oefenscript maar ik gebruik het nu voor local origin.
    /// </summary>
    [SerializeField]
    private ARSessionOrigin arSessionOrigin;
    //De coördinaten van locatie 1.
    [SerializeField]
    private float latitude = (float)51.924035;

    [SerializeField]
    private float longitude = (float)4.480431;

    private void Start()
    {
        GPSEncoder.SetLocalOrigin(new Vector2((float)51.9240374848728, (float)4.480468332950854));
        arSessionOrigin.transform.position = GPSEncoder.GPSToUCS(latitude, longitude);
    }
}