using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heightAdjustment : MonoBehaviour
{
    public Text heightInput;

    public void function()
    {
        int i = Convert.ToInt32(heightInput);
        var position = gameObject.transform.position;
        position.y = i;
    }
}
