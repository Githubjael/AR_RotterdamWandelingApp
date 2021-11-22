using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class latlonCoordsToUCS : MonoBehaviour
{
    [SerializeField] public float latitude = (float)51.92720126705968;
    [SerializeField] public float longitude = (float)4.480318333635156;
    [SerializeField] GameObject observerGameObject;

    public void Update()
    {
        Vector3 xyz_vector =  Quaternion.AngleAxis(longitude, -Vector3.up) * Quaternion.AngleAxis(latitude, -Vector3.right) * new Vector3(0, 0, 1);
        observerGameObject.transform.position = xyz_vector;
    }
}
