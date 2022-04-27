using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject ListOfTexts;
    [SerializeField] List<RectTransform> Locs;
    void Start()
    {
        GetLoT();
        ListAllChildren();
    }
    
    public void GetLoT()
    {
        ListOfTexts = canvas.transform.Find("ListOfTexts").gameObject;
    }

    public void ListAllChildren()
    {
        foreach(RectTransform children in ListOfTexts.transform)
        {
            Locs.Add(children.GetComponent<RectTransform>());
        }
    }
}
