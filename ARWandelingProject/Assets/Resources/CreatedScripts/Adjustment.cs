using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class Adjustment : MonoBehaviour
{
    [SerializeField]private ARSessionOrigin sessionOrigin;
    public GameObject Content;
    [SerializeField]private int i = 0;
    public Camera Camera;
    public Slider slider;

    public void Start()
    {
        sessionOrigin = FindObjectOfType<ARSessionOrigin>();
        //Camera = GetComponent<Camera>();
    }

    public void heightAdjustmentUP()
    {
        i++;
        var a = Camera.transform.position;
        Camera.transform.position = new Vector3(a.x, i, a.z);
    }
    public void heightAdjustmentDOWN()
    {
        i--;
        var a = Camera.transform.position;
        Camera.transform.position = new Vector3(a.x, i, a.z);
    }
    public void OnvalueChange(float value)
    {
        Debug.Log("New Value:" + value);
        //Transform t = gameObject.transform;
        sessionOrigin.MakeContentAppearAt(Content.transform, Quaternion.identity);

        Content.transform.localScale = new Vector3(value, value, value);
        float scale = slider.value;
        sessionOrigin.transform.localScale = Vector3.one * scale;

    }
}
