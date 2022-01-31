using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraRig : MonoBehaviour
{
    public Transform target;
    public float desiredDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 vToTarget = target.position - transform.position;

        //position
        Vector3 targetPosition = -vToTarget;
        targetPosition.Normalize();
        targetPosition *= desiredDistance;//vector from target's position in direction of camera
        targetPosition += target.position;
        transform.position = AnimMath.Ease(transform.position, targetPosition, .01f);

        //turn to look at target        
        transform.rotation = Quaternion.LookRotation(vToTarget, Vector3.up);
    }
}
