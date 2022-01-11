using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquirectangularProjection : MonoBehaviour
{
    public float Radius = 6371 * 1000;
    public float longitude;
    public float latitude;

    public float central_meridian = 6;
    public float parallel_meridian;

    public List<GameObject> Content = new List<GameObject>();
    public void Function()
    {
/*        for(int i = 0; i < Content.Length; i++)
        {
            x_vector();
            y_vector();
        }*/
    }

    public float Xix,(float x)
    {
        x = Radius * (longitude / central_meridian) * Mathf.Cos(parallel_meridian);
        return x;
    }

    public float Yaxis(float y)
    {
        y = Radius * ( latitude * parallel_meridian);
        return y;
    }
    public struct Convert
    {
        
    }
}
