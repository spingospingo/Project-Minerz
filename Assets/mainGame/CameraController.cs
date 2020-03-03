using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool camStatus = false;
    private Vector3 currentPos;

    // Variables for panning
    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;
    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;

    // Variables for camera follow
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    void Update()
    {
        Vector3 pos = transform.position;

        // Key controls for panning
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        // Zoom in/out
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100 * Time.deltaTime;

        // Limits how far you can zoom in/out
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, +panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, +panLimit.y);

        transform.position = pos;
        currentPos = pos;

        // Camera Follow
        if (Input.GetKeyDown(KeyCode.Space) && camStatus == false)
        {
            camStatus = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            camStatus = false;
        }
    }

    // Smooth follow; currently set to follow at a certain offset; need to figure out how to make the camera follow at any Y distance
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        if (camStatus == true)
        {
            transform.position = smoothedPosition;
        }
        else if(camStatus == false)
        {
            transform.position = currentPos; // If space is let go, the camera stays at the spot you let go at
        }


    }
}
