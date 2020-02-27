using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camControls : MonoBehaviour
{
    private Camera overheadCam;
    private int camStatus;

    private float minDist = 0;// 20 + 0 = real min of 20
    private float maxDist = 95f;// 20 + 95 = real max of 115
    private float scrollSens = 35f;
    private float camDist = 20f;

    private Vector3 scrollPos;
    /*-------------------------------------
     *camStatus: 0 = overhead camera view
     *            1 = player camera view
     *-------------------------------------*/

    private Vector3 overheadPos;
    public GameObject player;
    public Vector3 offset;

    void Start()
    {
        //establish initial overhead cam
        overheadPos = Camera.main.transform.position;
        //establish initial zoom value
        camDist = Camera.main.transform.position.y;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//consider changing to "space"
        {
            camStatus = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            camStatus = 0;
        }
    }

    //LateUpdate() runs after Update(), so camera moves after all ingame motions are calculated
    void LateUpdate()
    {
        scrollPos = getZoom();

        if (camStatus == 0)
        {
            transform.position = overheadPos + scrollPos;
        }
        else if (camStatus == 1)
        {
            transform.position = player.transform.position + offset + scrollPos;
        }
    }

    private Vector3 getZoom()
    {
        camDist -= Input.GetAxis("Mouse ScrollWheel") * scrollSens;
        camDist = Mathf.Clamp(camDist, minDist, maxDist);
        scrollPos = new Vector3(0, camDist, 0);
        return scrollPos;
    }
}
