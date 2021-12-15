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

    public void Start()
    {
        sessionOrigin = FindObjectOfType<ARSessionOrigin>();
        //Camera = GetComponent<Camera>();
    }

    public void heightAdjustmentUP()
    {
        i++;
        Camera.transform.position = new Vector3(0, i, 0);
    }
    public void heightAdjustmentDOWN()
    {
        i--;
        Camera.transform.position = new Vector3(0, i, 0);
    }
    public void OnvalueChange(float value)
    {
        Debug.Log("New Value:" + value);
        //Transform t = gameObject.transform;
        sessionOrigin.MakeContentAppearAt(Content.transform, Quaternion.identity);

        Content.transform.localScale = new Vector3(value, value, value);
        sessionOrigin.transform.localScale = new Vector3(value, value, value);
    }
}
