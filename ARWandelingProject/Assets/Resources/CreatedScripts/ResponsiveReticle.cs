using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResponsiveReticle : MonoBehaviour
{
    [SerializeField] RectTransform reticle;
    public RectTransform reticleText;
    public Transform player;

    public float maxSize;
    public float minSize;
    private float currentSize;
    public float speed;

    RaycastHit hit;

    private void FixedUpdate()
    {
        if (IsInteractable)
        {
            reticleText.gameObject.SetActive(true);
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed);
        }
        else
        {
            reticleText.gameObject.SetActive(false);
            currentSize = Mathf.Lerp(currentSize, minSize, Time.deltaTime * speed);
        }
        reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }
    public bool IsInteractable
    {
        get
        {
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
