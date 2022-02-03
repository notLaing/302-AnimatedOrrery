using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform orbitCenter;
    public float radius = 3f;
    public float offsetTime = 0f;
    public float orbitSpeed = 1f;
    public int pathResolution = 32;

    //moon variables
    public Vector3 moonAway = Vector3.zero;//the starting point of the moon's orbit
    Vector3 moonUp;
    bool doOnce = true;
    public bool moon = false;//set true only for moons, since they won't orbit the same way planets do

    LineRenderer path;

    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<LineRenderer>();
        path.loop = true;
        path.useWorldSpace = true;
        path.startWidth = .1f;
        path.endWidth = .1f;

        if(moon) moonAway.Normalize();

        UpdateOrbitPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (!orbitCenter) return;

        if (!moon)
        {
            float x = Mathf.Cos((Time.time * orbitSpeed) + offsetTime) * radius;
            float z = Mathf.Sin((Time.time * orbitSpeed) + offsetTime) * radius;

            transform.position = new Vector3(x, 0, z) + orbitCenter.position;

            if (orbitCenter.hasChanged) UpdateOrbitPath();
        }
        else
        {
            //we have a Vector3 for position of a planet and the desired start point of a moon's orbit. We can force the moon to face the direction of the planet to start
            transform.position = orbitCenter.position + (moonAway * radius);
            transform.LookAt(orbitCenter);
            if(doOnce)
            {
                doOnce = false;
                moonUp = transform.up;
            }
            //after moon is facing planet, do the thing Earth's moon does: pretty much just face the planet and orbit to the moon's side
            //set a Vec3 at the start to be the original transform.up. This way the moon can still orbit independently of its spin (i.e. if a moon's up direction changes from spin, it still orbits)
            transform.RotateAround(orbitCenter.position, moonUp, orbitSpeed * Time.time);

            if (orbitCenter.hasChanged) UpdateMoonOrbitPath();
        }
    }

    //update path of planets
    void UpdateOrbitPath()
    {
        if (!orbitCenter) return;

        float radsPerCircle = Mathf.PI * 2f;

        Vector3[] pts = new Vector3[pathResolution];

        for (int i = 0; i < pts.Length; ++i)
        {
            float x = radius * Mathf.Cos(i * radsPerCircle / pathResolution);
            float z = radius * Mathf.Sin(i * radsPerCircle / pathResolution);

            Vector3 pt = new Vector3(x, 0, z) + orbitCenter.position;
            pts[i] = pt;
        }
        path.positionCount = pathResolution;
        path.SetPositions(pts);
    }

    //update path of moons
    void UpdateMoonOrbitPath()
    {
        if (!orbitCenter) return;

        float degPerCircle = 360f;

        Vector3[] pts = new Vector3[pathResolution];

        for (int i = 0; i < pts.Length; ++i)
        {
            //move the moon to where it would be, grab the point, then move it back
            transform.RotateAround(orbitCenter.position, moonUp, i * degPerCircle / pathResolution);
            Vector3 pt = transform.position;
            pts[i] = pt;
            transform.RotateAround(orbitCenter.position, moonUp, -i * degPerCircle / pathResolution);
        }
        //reset to the position/rotation it should be
        transform.RotateAround(orbitCenter.position, moonUp, orbitSpeed * Time.time);
        transform.GetComponent<Spin>().MoonRotate();
        path.positionCount = pathResolution;
        path.SetPositions(pts);
    }
}
