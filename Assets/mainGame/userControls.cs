using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userControls : MonoBehaviour
{
    private LayerMask navigable, interactable;

    private Ray clickRay;
    private Camera cam;
    private playerBehavior player;

    private GameObject selectedObject;
    public GameObject SelectedObject
    {
        get { return selectedObject; }
        set { }
    }

    // Start is called before the first frame update
    void Start()
    {
        selectedObject = GameObject.Find("Floor"); //instantiate to "no selection"
        navigable = LayerMask.GetMask("Floor");
        interactable = LayerMask.GetMask("Interactable");
        cam = Camera.main;
        player = GameObject.Find("Player").GetComponent<playerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //right click
        {
            clickRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            //if ray collides with an interactable object...
            if (Physics.Raycast(clickRay, out hitInfo, Mathf.Infinity, navigable | interactable))
            {
                player.controlPlayer(hitInfo);
            }
        }
        else if (Input.GetMouseButtonDown(0)) //left click
        {
            selectObject();
        }
    }

    private void selectObject()
    {
        clickRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        //if ray collides with ground OR object
        if (Physics.Raycast(clickRay, out hitInfo, Mathf.Infinity, navigable | interactable))
        {
            selectedObject = hitInfo.collider.gameObject;
        }
    }
}
