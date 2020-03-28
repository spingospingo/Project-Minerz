using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNightCycleTimer3DSphere : MonoBehaviour
{
    private GameObject sphereObject;
    private float cycleTimeScale;

    private Vector3 initialCameraPos;
    private Vector3 initialSpherePos;
    private Vector3 currentCameraPos;
    private Vector3 currentSpherePos;
    private Vector3 vectorDifference;

    void Start()
    {

        getTimerComponents();
        getCameraComponents();

    }

   
    void Update()
    {
        rotateSphere();
        updatePositionFromCamera();
    }

    private void getTimerComponents()
    {
        sphereObject = gameObject;

        currentSpherePos = sphereObject.transform.localPosition;

        cycleTimeScale = GameObject.Find("Sun").GetComponent<lightOrbit>().TimeScale;

        currentCameraPos = GameObject.Find("Camera").GetComponent<CameraController>().CurrentPos;
    }

    private void getCameraComponents()
    {
        initialCameraPos = currentCameraPos;
        initialSpherePos = currentSpherePos;

        vectorDifference = currentSpherePos - currentCameraPos;
        Debug.Log("Vector Difference: " + vectorDifference);
        Debug.Log("Camrea Position: " + currentCameraPos);
    }

    private void rotateSphere()
    {
        //Rotate transformation component about z axis at "cycleTimeScale" units per second
        sphereObject.transform.Rotate(0, 0, cycleTimeScale * Time.deltaTime);
    }

    private void updatePositionFromCamera()
    {
        currentCameraPos = GameObject.Find("Camera").GetComponent<CameraController>().CurrentPos;
        currentSpherePos = currentCameraPos + vectorDifference;
        sphereObject.transform.localPosition = currentSpherePos;
    }

}
