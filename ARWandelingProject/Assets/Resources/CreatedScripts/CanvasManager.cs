using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject ListOfTexts;
    [SerializeField] List<RectTransform> Locs;
    [SerializeField] List<Transform> TheDeets;
    void Start()
    {
        GetLoT();
        ListAllChildren();
        ListChildrenInTheChildren();
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

    public void ListChildrenInTheChildren()
    {
        for(int i = 0; i < Locs.Count; i++)
        {
            foreach(RectTransform texts in Locs[i])
            {
                TheDeets.Add(texts.gameObject.transform);
            }
        }
    }
}
