using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordToBuildingPlacement : MonoBehaviour
{
    public float longitude;
    public float latitude;
    private float latScale;
    private float lonScale;
    [SerializeField]
    private List<GameObject> Buildings;

    public void Start()
    {
        GeoCoordsToUnityCoords();
    }

    private void GeoCoordsToUnityCoords()
    {
        latScale = gameObject.transform.position.y / 180;
        latScale = gameObject.transform.position.x / 360;


    }
}
