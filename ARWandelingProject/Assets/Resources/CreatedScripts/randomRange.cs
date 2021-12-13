using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRange : MonoBehaviour
{
    public int minValue;
    public int height;
    public int maxValue;
    public void Start()
    {
        function();
    }

    public void function()
    {
        var position = gameObject.transform;
        position.position = new Vector3(Mathf.Round(Random.Range(minValue, maxValue)), height, Mathf.Round(Random.Range(minValue, maxValue)));
    }
}
