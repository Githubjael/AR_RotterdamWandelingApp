using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clampAt : MonoBehaviour
{
    public int minValue;
    public int maxValue;
    void Update()
    {
        function();
    }

    public void function()
    {
        var position = gameObject.transform.position;
        Mathf.Clamp(position.y, minValue, maxValue);
        gameObject.transform.position = position;
    }
}
