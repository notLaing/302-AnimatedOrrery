using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCameraRig : MonoBehaviour
{
    public Transform target;

    float pitch = 0f;
    float yaw = 0f;
    float distToTarget = 10f;
    float mx, my;
    public float mouseSensitivityX = 1f;
    public float mouseSensitivityY = -1f;
    public float scrollSensitivity = 3f;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    void LateUpdate()
    {
        //rotation
        mx = Input.GetAxis("Mouse X");//yaw (Y)
        my = Input.GetAxis("Mouse Y");//pitch (X)

        yaw += mx * mouseSensitivityX;
        pitch += my * mouseSensitivityY;
        pitch = Mathf.Clamp(pitch, -89f, 89f);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);

        //zoom
        Vector2 scrollAmount = Input.mouseScrollDelta;
        distToTarget += scrollAmount.y * scrollSensitivity;
        distToTarget = Mathf.Clamp(distToTarget, 5, 50);

        float z = AnimMath.Ease(cam.transform.localPosition.z, -distToTarget, .01f);
        cam.transform.localPosition = new Vector3(0, 0, z);

        //position
        if (target == null) return;
        //transform.position = target.position;
        transform.position = AnimMath.Ease(transform.position, target.position, .001f, Time.deltaTime);
    }
}
