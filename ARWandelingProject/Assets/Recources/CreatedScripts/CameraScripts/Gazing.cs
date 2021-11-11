using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gazing : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private GameObject Observer;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(arCamera.transform.position, arCamera.transform.forward);
        RaycastHit hitsInfo;

        if (Physics.Raycast(ray , out hitsInfo))
        {
            Debug.DrawLine(ray.origin, hitsInfo.point);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100f, Color.white);
        }
    }
}
