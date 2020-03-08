using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerBehavior : MonoBehaviour
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
                    //mark interactableCheckTest as false and has attributeType of -1 (no attribute type)
                    interactableCheckTest = false;
                    attributeType = -1;
                }




                else if (Input.GetKeyDown("g"))
                {
                    playerAgent.SetDestination(Vector3.zero);
                }
            }
        }
    }



    private void interactableAttributesCheck()
    //if interactableCheckTest is true
    {
        if (interactableCheckTest == true)
        {


            //if interactable object clicked contains mineralAttributes
            mineralAttributes mineralAttributesCheck = interactableGameObject.GetComponent<mineralAttributes>();
            if (mineralAttributesCheck != null)
            {
                //public variable guiMineralAmount = Mineral Amount of interactable object clicked
                guiMineralAmount = mineralAttributesCheck.MineralAmount;
                guiTypeMineral = mineralAttributesCheck.TypeMineral;
                attributeType = 0;
              
            }

            buildingAttributes buildingAttributesCheck = interactableGameObject.GetComponent<buildingAttributes>();
            if (buildingAttributesCheck != null)
            { attributeType = 1; }

        }

    }

}


