using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.XR.ARFoundation;

public class SetToCurrentCoords : MonoBehaviour
{
    [SerializeField]
    private ARSessionOrigin arSessionOrigin;

    [SerializeField]
    private float latitude = (float)51.924035;

    [SerializeField]
    private float longitude = (float)4.480431;

    private void Start()
    {
        GPSEncoder.SetLocalOrigin(new Vector2(latitude, longitude));
    }
}