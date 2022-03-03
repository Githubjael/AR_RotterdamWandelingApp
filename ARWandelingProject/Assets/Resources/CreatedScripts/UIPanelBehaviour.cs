using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIPanelBehaviour : MonoBehaviour
{
    /*
     * wanneer de reticle op de cube is en het object is interactable dan opent het de respectief UI Panel voor die cube:
     * cube in LOC1, opent loc1 panel
     */
    public RectTransform ParentObject;
    [SerializeField] Transform obj;

    private void Start()
    {
        obj = transform.Find("loc1");
    }
    private void Update()
    {
        DetectInput();
    }
    void DetectInput()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Space))
        {
            ParentObject.gameObject.SetActive(true);
            foreach(RectTransform Panel in ParentObject)
            {
                if (obj)
                {
                    Panel.gameObject.SetActive(true);
                    obj.gameObject.SetActive(true);
                }
                else
                {
                    Panel.gameObject.SetActive(false);
                    obj.gameObject.SetActive(false);
                }
            }
        }
    }
}
