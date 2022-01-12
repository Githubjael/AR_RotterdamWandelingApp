using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquirectangularProjection : MonoBehaviour
{
    public float Radius = 6371 * 1000;
    public Convert convert;

    public float central_meridian = 6;
    public float parallel_meridian;

    public List<GameObject> Content = new List<GameObject>();
    public void Function()
    {

    }
    public struct Convert
    {
        public float longitude;
        public float latitude;
    }
}
