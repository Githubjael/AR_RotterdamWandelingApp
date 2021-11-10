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
        Gaze();
    }

    public void Update()
    {
        
    }

    public void Gaze()
    {
        /*
         * foreach (Touch touch in Input.touches)
            {
                if(Input.touchCount > 0 && touch.phase == TouchPhase.Began || Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
                {
                    if(Physics.Raycast(ray, out hitsInfo))
                    {
                        Debug.Log($"{hitsInfo.collider.tag}");
                        Debug.DrawLine(ray.origin, hitsInfo.point, Color.red);
                        if(hitsInfo.collider.tag == "testTag1")
                        {
                            Infopanel.SetActive(true);
                        }
                        else
                        {
                            Debug.Log("You fuckin up!");
                        }
                    }
                    else
                    {
                        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100f, Color.green);
                    }
                }
            }
        */
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(0.5f,0.5f));
        RaycastHit hitsInfo;

        
    }
}
