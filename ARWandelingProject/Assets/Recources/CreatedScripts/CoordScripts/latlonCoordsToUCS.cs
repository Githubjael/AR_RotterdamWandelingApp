using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class latlonCoordsToUCS : MonoBehaviour
{
    /// <summary>
    /// Dit was een script gevonden op een een forum post ergens. Voor mij werkte het niet
    /// echt uit voor dit project. Deze script wordt niet gebruikt op dit moment, het wordt
    /// verwijdert op een latere datum als er geen gebruikk voor deze script is.
    /// </summary>
    [SerializeField] public float latitude = (float)51.92720126705968;
    [SerializeField] public float longitude = (float)4.480318333635156;
    [SerializeField] GameObject observerGameObject;

    public void Update()
    {
        Vector3 xyz_vector =  Quaternion.AngleAxis(longitude, -Vector3.up) * Quaternion.AngleAxis(latitude, -Vector3.right) * new Vector3(0, 0, 1);
        observerGameObject.transform.position = xyz_vector;
    }
}
