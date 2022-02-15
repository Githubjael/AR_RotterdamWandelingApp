using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationInfoPanel : MonoBehaviour
{
    public ResponsiveReticle responsiveReticle;

    private void Start()
    {
        OpenInfoPanel();
    }
    public void OpenInfoPanel()
    {
        if (responsiveReticle.isInteractable)
        {
            Debug.Log("Ey!");
        }
    }
}
