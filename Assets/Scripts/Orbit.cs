using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform orbitCenter;
    public float radius = 3f;
    public float offsetTime = 0f;
    public float yAdjust = 0f;
    public int pathResolution = 32;

    LineRenderer path;

    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<LineRenderer>();
        path.loop = true;
        path.useWorldSpace = true;
        path.startWidth = .1f;
        path.endWidth = .1f;
        UpdateOrbitPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (!orbitCenter) return;
        float x = Mathf.Cos(Time.time + offsetTime) * radius;
        float z = Mathf.Sin(Time.time + offsetTime) * radius;

        transform.position = new Vector3(x, 0, z) + orbitCenter.position;

        if (orbitCenter.hasChanged) UpdateOrbitPath();
    }

    void UpdateOrbitPath()
    {
        if (!orbitCenter) return;

        float radsPerCircle = Mathf.PI * 2f;

        Vector3[] pts = new Vector3[pathResolution];

        for (int i = 0; i < pts.Length; ++i)
        {
            float x = radius * Mathf.Cos(i * radsPerCircle / pathResolution);
            float z = radius * Mathf.Sin(i * radsPerCircle / pathResolution);

            Vector3 pt = new Vector3(x, yAdjust, z) + orbitCenter.position;
            pts[i] = pt;
        }
        path.positionCount = pathResolution;
        path.SetPositions(pts);
    }
}
