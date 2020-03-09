using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerBehavior : MonoBehaviour
{
    private LayerMask navigable; //mesh that can be clicked on for movement
    private LayerMask interactable; //rocks, buildings, minerals, etc

    private NavMeshAgent playerAgent;
    private Ray clickRay;
    private Camera cam;

    private GameObject selectedObject;
    public GameObject SelectedObject
    {
        get { return selectedObject; }
        set { }
    }

    private string objectType;
    public string ObjectType
    {
        get { return objectType; }
        set { }
    }

    void Start()
    {
        cam = Camera.main;
        playerAgent = GetComponent<NavMeshAgent>();
        navigable = LayerMask.GetMask("Floor");
        interactable = LayerMask.GetMask("Interactable");
    }

    void OnGUI()
    {
        if (Input.GetMouseButtonDown(1)) //right click
        {
            movePlayer();
        }
        else if (Input.GetMouseButtonDown(0)) //left click
        {
            selectObject();
        }
    }

    private void movePlayer()
    {
        //instantiate path variable to check if 
        NavMeshPath path = new NavMeshPath();

        //shoots ray from camera towards mouseclick
        clickRay = cam.ScreenPointToRay(Input.mousePosition);
        //point of collision from camera raycast
        RaycastHit hitInfo;

        //if ray collides with an interactable object...
        if (Physics.Raycast(clickRay, out hitInfo, 150, interactable))
        {
            //Set object to interactableGameObject and get object attributes
            selectedObject = hitInfo.collider.gameObject;

            playerAgent.CalculatePath(hitInfo.point, path);
            //if player can move to the point...
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                //...tell player to move to that point
                playerAgent.SetDestination(hitInfo.point);
            }
        }
        //if ray collides with navmesh...
        else if (Physics.Raycast(clickRay, out hitInfo, 150, navigable))
        {
            playerAgent.CalculatePath(hitInfo.point, path);
            //if player can move to the point...
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                //...tell player to move to that point
                playerAgent.SetDestination(hitInfo.point);
            }
        }
    }

    private void selectObject()
    {
        clickRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        //if object is "interactable"
        if (Physics.Raycast(clickRay, out hitInfo, 150, interactable))
        {
            //Set object to interactableGameObject and get object attributes
            selectedObject = hitInfo.collider.gameObject;
            getInteractableAttributes();
        }
        //if object does not have tag "interactable"
        else
        {
            objectType = "none";
        }
    }

    private void getInteractableAttributes()
    {
        //if interactable object clicked is a rock
        if (selectedObject.name == "Rock(Clone)" || selectedObject.name == "bigRock(Clone)")
        {
            objectType = "rock";
        }

        //if interactable object clicked is a mineral
        mineralAttributes mineralAttributesCheck = selectedObject.GetComponent<mineralAttributes>();
        if (mineralAttributesCheck != null) { objectType = "mineral"; }

        //if interactable object clicked is a building
        buildingAttributes buildingAttributesCheck = selectedObject.GetComponent<buildingAttributes>();
        if (buildingAttributesCheck != null) { objectType = "building"; }
    }
}


