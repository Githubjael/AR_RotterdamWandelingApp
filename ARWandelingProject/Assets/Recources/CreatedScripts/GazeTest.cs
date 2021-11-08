using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteInEditMode]
public class GazeTest : MonoBehaviour, InformationInterface
{
    [SerializeField]
    private GameObject Cursor;

    [SerializeField]
    private GameObject Observer;

    [SerializeField]
    private GameObject infoPrompt;

    [SerializeField]
    private TextMeshProUGUI information;


    public void Gaze()
    {
        Ray ray = new Ray(Observer.transform.position, Observer.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.green);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100, Color.red);
        }
        Debug.DrawRay(ray.origin, hitInfo.point, Color.white);
        if (hitInfo.collider.tag == "TestTag1")
        {
            Debug.Log("Hello!");
            infoPrompt.SetActive(true);
        }
    }
}