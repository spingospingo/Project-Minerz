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

    private int guiMineralAmount;
    public int GuiMineralAmount
    {
        get { return guiMineralAmount; }
        set { }
    }

    private string guiTypeMineral;
    public string GuiTypeMineral
    {
        get { return guiTypeMineral; }
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
        movePlayer();
        interactableTrueCheck();
    }

    private void movePlayer()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //shoots ray from camera towards mouseclick
            clickRay = cam.ScreenPointToRay(Input.mousePosition);
            //point of collision from camera raycast
            RaycastHit hitInfo;

            //if ray collides with navmesh...
            if (Physics.Raycast(clickRay, out hitInfo, 150, navigable))
            {
                //...tell player to move to that point
                playerAgent.SetDestination(hitInfo.point);
            }
        }
    }

    private void interactableTrueCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            //if object is "interactable"
            if (Physics.Raycast(clickRay, out hitInfo, 150, interactable))
            {
                //Set object to interactableGameObject and mark interactableCheckTest as true
                interactableGameObject = hitInfo.collider.gameObject;
                interactableAttributesCheck();
            }
            else //if object does not have tag "interactable"
            {
                //mark interactableCheckTest as false and has attributeType of -1 (no attribute type)
                attributeType = "none";
            }
        }
    }

    private void interactableAttributesCheck()
    {
        //if interactable object clicked contains mineralAttributes
        mineralAttributes mineralAttributesCheck = interactableGameObject.GetComponent<mineralAttributes>();
        if (mineralAttributesCheck != null)
        {
            //public variable guiMineralAmount = Mineral Amount of interactable object clicked
            guiMineralAmount = mineralAttributesCheck.MineralAmount;
            guiTypeMineral = mineralAttributesCheck.name;
            attributeType = "mineral";
        }

        buildingAttributes buildingAttributesCheck = interactableGameObject.GetComponent<buildingAttributes>();
        if (buildingAttributesCheck != null) { attributeType = "building"; }
    }
}


