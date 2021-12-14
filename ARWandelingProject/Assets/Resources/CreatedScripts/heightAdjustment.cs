using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class heightAdjustment : MonoBehaviour
{
    public Text heightInput;
    public Camera Camera;

    public void function()
    {
        int i = Convert.ToInt16(heightInput.text);
        var position = Camera.transform.position;
        position.y = i;
    }
}
