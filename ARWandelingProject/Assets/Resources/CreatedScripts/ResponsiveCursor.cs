using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResponsiveCursor : MonoBehaviour
{
    private RectTransform cursor;

    [SerializeField]
    private float startSize;
    
    [SerializeField]
    private float endSize;

    public Transform playerObject;
    public Camera arCamera;

    Ray ray;
    RaycastHit hit;
    LayerMask interactable;

    private bool isOnInteractable;
    // Start is called before the first frame update
    void Start()
    {
        cursor = GetComponent<RectTransform>();
            }

    private void Update()
    {
        ray.origin = playerObject.transform.position;
        ray.direction = playerObject.TransformDirection(Vector3.forward);
        Responsive();
    }

    void Responsive()
    {
        Debug.DrawLine(ray.origin, ray.direction, Color.red);
        if (Physics.Raycast(ray.origin, ray.direction * 5f, out hit))
        {
            Debug.Log(hit.collider.name);
            isOnInteractable = true;
            if (interactable == LayerMask.GetMask("Interactable"))
            {
                cursor.localScale = new Vector2(endSize, endSize);
            }
        }
        else if(isOnInteractable == false)
        {
            cursor.localScale = new Vector2(startSize, startSize);
        }
    }
}
