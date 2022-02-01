using UnityEngine;

public class SightLines : MonoBehaviour
{
    public Transform player;
    public Camera arCamera;

    [SerializeField]
    private RectTransform transformCursor;

    [SerializeField]
    private float startScale = 0.25f;

    [SerializeField]
    private float endScale = 0.75f;

    [SerializeField]
    [Range(0f, 5f)]
    private float smoothValue = 2f;

    [SerializeField]
    [Range(0.25f, 0.75f)]
    private float size;


}
