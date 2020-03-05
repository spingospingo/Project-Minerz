using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightOrbit : MonoBehaviour
{
    private Vector3 axis = new Vector3(0, 0, 1);
    private Vector3 focalPoint = new Vector3(0, 0, -120);

    private float timeScale = 1f;

    public float TimeScale
    {
        get
        {
            return timeScale;
        }
        set
        {
            timeScale = value;
        }
    }

    void Update()
    {
        transform.RotateAround(Vector3.zero, axis, 
            timeScale * Time.deltaTime);
        transform.LookAt(focalPoint);
    }

    public void setDayLength(int length)
    {
        timeScale = 180f / length;
    }
}
