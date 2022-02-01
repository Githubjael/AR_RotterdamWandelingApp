using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class ResponsiveCursor : MonoBehaviour
{
    private RectTransform cursor;

    Ray ray;
    RaycastHit hit;

    public Transform player;

    Vector3 minScale;
    public Vector3 maxScale;
    public bool interactable;
    public float speed = 2f;
    public float duration = 5f;

    public IEnumerator Responsive(Vector3 a, Vector3 b, float time)
    {
        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while(i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }
}
