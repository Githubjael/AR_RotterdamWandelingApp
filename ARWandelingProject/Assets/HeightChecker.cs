using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;

public class HeightChecker : MonoBehaviour
{
    [SerializeField] Text heightInput;

    public void function()
    {
        int result = Convert.ToInt32(heightInput.text);
        var position = gameObject.transform.position;
        position.y = result;
    }
}
