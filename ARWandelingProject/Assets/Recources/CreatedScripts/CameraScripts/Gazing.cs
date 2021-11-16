using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gazing : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private GameObject Observer;

    [SerializeField]
    private GameObject infoPanel;

    private void Start()
    {
        arCamera.transform.parent = Observer.transform;
    }

    void Update()
    {
        Ray ray = new Ray(arCamera.transform.position, arCamera.transform.forward);
        RaycastHit hitsInfo;

        if (Input.GetMouseButtonUp(0) || Input.touchCount > 0)
        {
            Physics.Raycast(ray, out hitsInfo);
            if (hitsInfo.collider.tag == "testTag1")
            {
                Debug.DrawLine(ray.origin, hitsInfo.point, Color.green);
                infoPanel.SetActive(true);
            }
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100f, Color.white);
            infoPanel.SetActive(false);
        }
    }
}
