using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResponsiveReticle : MonoBehaviour
{
    private RectTransform reticle;
    public Transform player;

    public TextMeshProUGUI interactionConfirmationText;

    public float maxSize;
    public float minSize;
    private float currentSize;
    public float speed;

    RaycastHit hit;

    private void Start()
    {
        reticle = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        if (isInteractable)
        {
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * speed);
            interactionConfirmationText.gameObject.SetActive(true);
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize, minSize, Time.deltaTime * speed);
            interactionConfirmationText.gameObject.SetActive(false);
        }
        
        reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }

    public bool isInteractable
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
