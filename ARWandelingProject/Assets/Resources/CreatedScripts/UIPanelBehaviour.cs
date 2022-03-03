using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIPanelBehaviour : MonoBehaviour
{
    /*
     * wanneer de reticle op de cube is en het object is interactable dan opent het de respectief UI Panel voor die cube:
     * cube in LOC1, opent loc1 panel
     */
    [SerializeField]ResponsiveReticle responsiveReticle;

    public RectTransform ParentObject;
    [SerializeField] RectTransform obj;

    private void Start()
    {
        //obj = (RectTransform)transform.Find("ListOfTexts/Loc1");
    }
    private void Update()
    {
        FindName();
        DetectInput();
    }
    void DetectInput()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Space))
        {
            ParentObject.gameObject.SetActive(true);
            foreach(RectTransform Panel in ParentObject)
            {
                obj.gameObject.SetActive(true);
            }
        }
    }
    void FindName()
    {
        if(responsiveReticle.hit.collider != null)
        {
            Debug.Log("ListOfTexts/" + responsiveReticle.hit.collider.name);
        }
        //obj = (RectTransform)transform.Find("ListOfTexts/"+ responsiveReticle.hit.collider.name);
    }
}
