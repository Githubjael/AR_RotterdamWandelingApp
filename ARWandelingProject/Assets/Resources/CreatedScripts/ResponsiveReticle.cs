using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class ResponsiveReticle : MonoBehaviour
{
    private RectTransform reticle;
    public Transform player;

    public float maxSize;
    public float minSize;
    private float currentSize;
    public float speed;

    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        ray.origin = player.position;
        ray.direction = player.TransformDirection(Vector3.forward);
        reticle = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (IsInteractable)
        {
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed);
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize, minSize, Time.deltaTime * speed);
        }
        reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }

    public bool IsInteractable
    {
        get
        {
            Debug.DrawLine(player.position, player.forward * 10f, Color.red);
            if (Physics.Raycast(player.position, player.forward * 10f, out hit))
            {
                if (hit.collider.tag == "Interactable")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
