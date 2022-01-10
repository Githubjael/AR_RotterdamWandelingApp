using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquirectangularProjection : MonoBehaviour
{
    public float Radius = 6371 * 1000;
    public float longitude;
    public float latitude;

    public float central_meridian;


    //public void 
    public float x_vector()
    {
        var x = Radius * (longitude / central_meridian) * Mathf.Cos(central_parallel);
        return x;
    }

    public float y_vector()
    {
        var y = Radius * (latitude / central_parallel);
        return y;
    }
}
