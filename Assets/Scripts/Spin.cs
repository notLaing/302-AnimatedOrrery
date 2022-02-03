using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    UI uiObj;
    //these must be set in the inspector. Determine the starting rotation
    public float xRot = 0f;
    public float yRot = 0f;
    public float zRot = 0f;
    public Vector3 rotateAbout = Vector3.zero;
    public float rotationSpeed;
    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localRotation = Quaternion.Euler(xRot, transform.localRotation.y, zRot);
        if (rotateAbout == Vector3.zero) rotateAbout = transform.up;
        else rotateAbout.Normalize();

        uiObj = FindObjectOfType<UI>();
    }

    void Update()
    {
        if(!uiObj.rewinding) time += Time.deltaTime;
        else time -= Time.deltaTime;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.RotateAround(transform.position, transform.up, rotationSpeed * Time.deltaTime);
        if(!uiObj.rewinding) transform.RotateAround(transform.position, rotateAbout, rotationSpeed * Time.deltaTime);
        else transform.RotateAround(transform.position, rotateAbout, rotationSpeed * -Time.deltaTime);
    }

    public void MoonRotate()
    {
        //transform.RotateAround(transform.position, transform.up, yRot * Time.time);
        transform.RotateAround(transform.position, rotateAbout, rotationSpeed * time);
    }
}
