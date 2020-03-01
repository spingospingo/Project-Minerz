using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public LayerMask navigable; //mesh that can be clicked on for movement
    //public Camera overheadCam;

    private NavMeshAgent playerAgent;
    private Ray clickRay;
    public Camera cam;

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    void OnGUI()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //shoots ray from camera towards mouseclick
            clickRay = cam.ScreenPointToRay(Input.mousePosition);
            //point of collision from camera raycast
            RaycastHit hitInfo; 

            //if ray collides with navmesh...
            if (Physics.Raycast (clickRay, out hitInfo, 150, navigable))
            {
                //...tell player to move to that point
                playerAgent.SetDestination(hitInfo.point);
            }
        }
        else if (Input.GetKeyDown("g"))
        {
            playerAgent.SetDestination(Vector3.zero);
        }
    }
}
