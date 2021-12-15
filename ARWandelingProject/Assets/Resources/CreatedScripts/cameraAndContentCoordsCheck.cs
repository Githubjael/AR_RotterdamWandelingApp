using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraAndContentCoordsCheck : MonoBehaviour
{
    public Text cameraCoordstext;
    public Text contentCoordstext;

    public GameObject arCamera;
    public GameObject contentGameobject;
    private void OnEnable()
    {
        contentGameobject = GameObject.Find("content");
        arCamera = GameObject.Find("AR Session Origin/AR Camera");
    }

    public void Update()
    {
        cameraCoordstext.text = arCamera.transform.position.ToString();
        contentCoordstext.text = contentGameobject.transform.position.ToString();
    }
}
