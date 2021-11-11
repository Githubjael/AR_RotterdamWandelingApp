using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GazeInteraction : MonoBehaviour
{
    List<InfoBehaviour> infos = new List<InfoBehaviour>();

    private void Start()
    {
        infos = FindObjectsOfType<InfoBehaviour>().ToList();
    }

    private void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("HoldsInfo"))
            {
                Debug.Log("Gazing Upon GameObject");
                OpenInfo(go.GetComponent<InfoBehaviour>());
            }
            else
            {
                CloseAll();
            }
        }
    }

    public void OpenInfo(InfoBehaviour dersiredInfo)
    {
        foreach(InfoBehaviour info in infos)
        {
            if(info == dersiredInfo)
            {
                info.OpenInfo();

            }
            else
            {
                info.CloseInfo();
            }
        }
    }

    public void CloseAll()
    {
        foreach (InfoBehaviour info in infos)
        {
            info.CloseInfo();
        }
    }
}
