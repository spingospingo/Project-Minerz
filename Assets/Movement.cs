using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public LayerMask navigable; //mesh that can be clicked on for movement
    public Camera overheadCam;
    public Camera playerCam;

    private NavMeshAgent playerAgent;
    private Ray clickRay;
    private Camera cam;

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    void OnGUI()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(overheadCam.enabled) //seems to run twice per click?
            {
                cam = overheadCam;
            }
            else if (playerCam.enabled)
            {
                cam = playerCam;
            }

            //shoots ray from camera towards mouseclick
            clickRay = cam.ScreenPointToRay(Input.mousePosition);
            //point of collision from camera raycast
            RaycastHit hitInfo; 

            //if ray collides with navmesh...
            if (Physics.Raycast (clickRay, out hitInfo, 100, navigable))
            {
                //...tell player to move to that point
                playerAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
