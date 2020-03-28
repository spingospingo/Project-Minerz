using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool camStatus = false;

    public Vector3 CurrentPos
    {
        get
        {
            return currentPos;
        }

        set
        {

        }
    }

    private Vector3 currentPos;

    // Variables for panning
    private float panSpeed = 30f;
    private float panBorderThickness = 10f;
    private Vector2 panLimit = new Vector2(90, 90);
    private float scrollSpeed = 30f;
    private float minY = 20f;
    private float maxY = 100f;

    // Variables for camera follow
    public Transform target;
    private float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0f, 0f, -15f);

    private Vector3 asdf = new Vector3(0, 0, 0);

    private void Start()
    {
        currentPos = gameObject.transform.position;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (camStatus == true)
        {
            offset = target.position + asdf;
        }
        if (Input.GetKeyDown(KeyCode.PageUp) && camStatus == false)
        {
            camStatus = true;
        }
        else if (Input.GetKeyDown(KeyCode.PageDown))
        {
            camStatus = false;
        }
        currentPos = cameraPan(pos);
        currentPos = Zoom(currentPos);
        transform.position = currentPos;
    }

    // Controls camera follow, figure out how to follow at changing y values
    void LateUpdate()
    {
        Vector3 desiredPosition = offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        if(camStatus == true)
        {
            transform.position = smoothedPosition;
        }
        else if(camStatus == false)
        {
            transform.position = currentPos;
        }
        
    }

    Vector3 Zoom(Vector3 pos)
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100 * Time.deltaTime;

        // Limits how far you can zoom in/out
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, +panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, +panLimit.y);
        return pos;
    }

    Vector3 cameraPan(Vector3 pos)
    {
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

        return pos;
    }
}
