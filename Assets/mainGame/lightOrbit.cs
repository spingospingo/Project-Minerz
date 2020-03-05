using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightOrbit : MonoBehaviour
{
    private Vector3 axis = new Vector3(0, 0, 1);
    /* focal point is slightly behind origin, to give a better perspective
     * for shadows */
    private Vector3 focalPoint = new Vector3(0, 0, -80);

    //length of day = 180 seconds / timeScale
    //Changed to timescale to public float to make GUI timer script
    public float timeScale = 1.5f;

    void Update()
    {
        transform.RotateAround(Vector3.zero, axis, 
            timeScale * Time.deltaTime);
        transform.LookAt(focalPoint);
    }
}
