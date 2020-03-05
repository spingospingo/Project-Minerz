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

        if (Input.GetMouseButtonDown(0))
        {
            clickRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(clickRay, out hitInfo))
            {
                Debug.Log(hitInfo.collider);

                //check for interactable component
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

                //If interactable component is clicked 
                if (interactable != null)
                {
                    Debug.Log("Left click hit interactable");
                }

                Debug.Log(interactable);
            }
            /* Currently clicks object twice and returns
             * null for second click.Apparently this code 
             * should written under void Update() instead 
             * of onGUI() to avoid this problem.            */



        }

        else if (Input.GetKeyDown("g"))
        {
            playerAgent.SetDestination(Vector3.zero);
        }
    }
}
