using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCam : MonoBehaviour
{
    private Camera overheadCam;
    private int camStatus;
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
    }

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            camStatus = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            camStatus = 0;
        }
    }

    /*LateUpdate() runs after Update(), so camera moves after all ingame motions
     * are calculated */
    void LateUpdate()
    {
        if(camStatus == 0)
        {
            transform.position = overheadPos;
        }
        else if (camStatus == 1) {
            transform.position = player.transform.position + offset;
        }
    }
}
