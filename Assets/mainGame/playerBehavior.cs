using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerBehavior : MonoBehaviour
{
    private LayerMask navigable; //mesh that can be clicked on for movement
    private LayerMask interactable; //rocks, buildings, minerals, etc

    private NavMeshAgent playerAgent;
    private GameObject interactableGameObject;
    private Ray clickRay;
    private Camera cam;

    private string attributeType;
    public string AttributeType
    {
        get { return attributeType; }
        set { }
    }

    private int objectMineralAmount;
    public int ObjectMineralAmount
    {
        get { return objectMineralAmount; }
        set { }
    }

    private string objectMineralType;
    public string ObjectMineralType
    {
        get { return objectMineralType; }
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
        NavMeshPath path = new NavMeshPath();

        //shoots ray from camera towards mouseclick
        clickRay = cam.ScreenPointToRay(Input.mousePosition);
        //point of collision from camera raycast
        RaycastHit hitInfo;

        //if ray collides with an interactable object...
        if (Physics.Raycast(clickRay, out hitInfo, 150, interactable))
        {
            //Set object to interactableGameObject and get object attributes
            interactableGameObject = hitInfo.collider.gameObject;
            //getInteractableAttributes();


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
            interactableGameObject = hitInfo.collider.gameObject;
            getInteractableAttributes();
        }
        //if object does not have tag "interactable"
        else
        {
            attributeType = "none";
        }
    }

    private void getInteractableAttributes()
    {
        //if interactable object clicked contains mineralAttributes
        mineralAttributes mineralAttributesCheck = interactableGameObject.GetComponent<mineralAttributes>();
        if (mineralAttributesCheck != null)
        {
            //public variable guiMineralAmount = Mineral Amount of interactable object clicked
            objectMineralAmount = mineralAttributesCheck.MineralAmount;
            objectMineralType = mineralAttributesCheck.name;
            attributeType = "mineral";
        }

        buildingAttributes buildingAttributesCheck = interactableGameObject.GetComponent<buildingAttributes>();
        if (buildingAttributesCheck != null) { attributeType = "building"; }
    }
}


