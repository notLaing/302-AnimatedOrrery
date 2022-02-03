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
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //update position
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = (transform.forward * v) + (transform.right * h);
        dir.Normalize();
        transform.position += dir * Time.unscaledDeltaTime * speed;

        //bound the position
        if (transform.position.x < -140f) transform.position = new Vector3(-140f, transform.position.y, transform.position.z);
        else if (transform.position.x > 140f) transform.position = new Vector3(140f, transform.position.y, transform.position.z);

        if (transform.position.y < -70f) transform.position = new Vector3(transform.position.x, -70f, transform.position.z);
        else if (transform.position.y > 70f) transform.position = new Vector3(transform.position.x, 70f, transform.position.z);

        if (transform.position.z < -65f) transform.position = new Vector3(transform.position.x, transform.position.y, -65f);
        else if (transform.position.z > 65f) transform.position = new Vector3(transform.position.x, transform.position.y, 65f);

        //update rotation - yaw (left/right), pitch (up/down), roll (take a guess)
        mx = Input.GetAxis("Mouse X");//yaw (Y)
        my = Input.GetAxis("Mouse Y");//pitch (X)

        yaw += mx * mouseSensitivityX;
        yaw = Mathf.Clamp(yaw, -89f, 89f);
        pitch += my * mouseSensitivityY;
        pitch = Mathf.Clamp(pitch, -89f, 89f);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
    }
}
