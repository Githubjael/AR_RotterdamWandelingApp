using UnityEngine;
[ExecuteInEditMode]
public class LookAtCamera : MonoBehaviour
{
    Transform Cam;

    Vector3 targetAngle = Vector3.zero;

    void Start()
    {
        Cam = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(Cam);
        targetAngle = transform.localEulerAngles;
        targetAngle.x = 0;
        targetAngle.z = 0;
        transform.localEulerAngles = targetAngle;
    }
}
