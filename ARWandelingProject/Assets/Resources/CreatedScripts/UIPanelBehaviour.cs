using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIPanelBehaviour : MonoBehaviour
{
    [SerializeField]ResponsiveReticle responsiveReticle;

    [SerializeField] RectTransform ParentObject;
    [SerializeField] RectTransform obj;

    private void Update()
    {
        FindName();
        DetectInput();
    }
    void DetectInput()
    {
        //de functie functie moet alleen door gaan als je scherm tapt. de rest is voor computer testen.
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Space))
        {
            obj.gameObject.SetActive(true);
        }
    }
    //om het naam te krijgen van het relevante object
    void FindName()
    {
        //de if statement is om te zorgen dat het niet de hele tijd gaat af gaat. Als je iets beter hebt, doe dat dan.
        if(responsiveReticle.hit.collider != null)
        {
            obj = (RectTransform)transform.Find("ListOfTexts/"+ responsiveReticle.hit.collider.name);
        }
        // dit is nodig om te voorkomen wanneer de reticle niet meer op de relevante object is.
        else
        {
            obj = null;
        }
    }
}
