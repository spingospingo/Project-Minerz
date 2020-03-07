using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public LayerMask navigable; //mesh that can be clicked on for movement

    private NavMeshAgent playerAgent;
    private GameObject interactableGameObject;

    private int attributeType;
    public int AttributeType
    {
        get { return attributeType; }
        set { }

    }

    private bool interactableCheckTest = false;
    private Ray clickRay;
    public Camera cam;
    public int guiMineralAmount;

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    void OnGUI()
    {
        movePlayer();
        interactableTrueCheck();
        interactableAttributesCheck();
    }

    void Update()
    {

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

            if (Physics.Raycast(clickRay, out hitInfo))
            {
                Debug.Log(hitInfo.collider);

                //if object has tag "Interactable"
                if (hitInfo.collider.gameObject.tag == "Interactable")  
                {

                //Set object to interactableGameObject and mark interactableCheckTest as true
                    interactableGameObject = hitInfo.collider.gameObject;
                    interactableCheckTest = true;

                    Debug.Log(interactableGameObject);

                    
                }
                //if object does not have tag "Interactable"
                if (hitInfo.collider.gameObject.tag != "Interactable")
                {
                //mark interactableCheckTest as false
                    interactableCheckTest = false;
                }




                else if (Input.GetKeyDown("g"))                         
                {
                    playerAgent.SetDestination(Vector3.zero);
                } 
            }
        }
    }



    private void interactableAttributesCheck()
    {   if(interactableCheckTest == true)
        {
            
            mineralAttributes mineralAttributesCheck = interactableGameObject.GetComponent<mineralAttributes>();
            if (mineralAttributesCheck != null)
            {
                guiMineralAmount = mineralAttributesCheck.MineralAmount;
                attributeType = 0;
            }

            buildingAttributes buildingAttributesCheck = interactableGameObject.GetComponent<buildingAttributes>();
            if (buildingAttributesCheck != null)
            { attributeType = 1; }

        }

    }


    
}
