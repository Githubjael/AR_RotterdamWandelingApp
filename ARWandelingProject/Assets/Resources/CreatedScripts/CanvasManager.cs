using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject ListOfTexts;
    [SerializeField] Canvas canvas;

    void Start()
    {
        GetLoT();
    }
    
    public void GetLoT()
    {
        ListOfTexts = canvas.transform.Find("ListOfTexts").gameObject;
    }

}
