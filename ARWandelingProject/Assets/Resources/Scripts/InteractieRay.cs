using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractieRay : MonoBehaviour
{
    public LayerMask mask;
    RaycastHit hitInfo;
    public Camera eyeOfTheBeholder;
    public Transform transformOfTheEye;

    private void Update()
    {
        Scanning();
    }

    public void Scanning()
    {
        Debug.DrawLine(transformOfTheEye.position, transformOfTheEye.forward * 100, Color.green);

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if(Physics.Raycast(eyeOfTheBeholder.transform.position, eyeOfTheBeholder.transform.forward, out hitInfo))
        {
            Debug.Log(hitInfo.transform.name);
        }
    }
}
