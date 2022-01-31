using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SightLines : MonoBehaviour
{
    public Transform player;
    public Camera arCamera;
    public RectTransform transformCursor;
    public float smoothValue = 2f;

    public void Update()
    {
        SightSeeing();
    }

    void SightSeeing()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hitInfo;
        Ray ray = new Ray(transform.position, fwd);

        Debug.DrawLine(transform.position, transform.position + fwd * 10f, Color.red);
        if (Physics.Raycast(transform.position, fwd, out hitInfo))
        {
            Debug.Log(hitInfo.collider.name);
            /*transformCursor.transform.localScale = new Vector3(0.75f, 0.75f, 0)*/
            var cursorScale = transformCursor.transform.localScale;
/*            cursorScale = Vector3.Lerp(cursorScale.x, , Time.fixedDeltaTime * smoothValue);
*/        }
        else
        {
            transformCursor.transform.localScale = new Vector3(-0.25f, -0.25f, 0);
        }
    }

    void LoreInteraction()
    {

    }
}
