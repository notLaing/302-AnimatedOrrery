using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightCameraRig : MonoBehaviour
{
    public float speed = 5f;
    float h, v, mx, my, pitch, yaw;
    float mouseSensitivityX = 1f;
    float mouseSensitivityY = -1f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //update position
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = (transform.forward * v) + (transform.right * h);
        dir.Normalize();
        transform.position += dir * Time.deltaTime * speed;

        //update rotation - yaw (left/right), pitch (up/down), roll (take a guess)
        mx = Input.GetAxis("Mouse X");//yaw (Y)
        my = Input.GetAxis("Mouse Y");//pitch (X)

        yaw += mx * mouseSensitivityX;
        pitch += my * mouseSensitivityY;
        pitch = Mathf.Clamp(pitch, -89f, 89f);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
    }
}
