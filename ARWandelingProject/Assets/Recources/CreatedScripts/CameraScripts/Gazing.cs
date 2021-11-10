using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class Gazing : MonoBehaviour
{
    [SerializeField]
    private GameObject Infopanel;
    [SerializeField]
    private Camera arCamera;
    [SerializeField]
    private ARRaycastManager arRaycastManager;
    [SerializeField]
    public TextMeshProUGUI dynamicText;

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public void Gaze()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(0.5f,0.5f));
        RaycastHit hits;

        foreach (Touch touch in Input.touches)
        {
            if(Input.touchCount > 0 && touch.phase == TouchPhase.Began)
            {
                Physics.Raycast( ray, out hits, 100f);
                Debug.DrawLine(ray.origin, hits.point, Color.green);
                if (hits.collider.tag == "testTag1")
                {
                    Infopanel.SetActive(true);
                }
            }
        }
    }
}
