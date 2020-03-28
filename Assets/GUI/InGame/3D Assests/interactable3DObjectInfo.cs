using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable3DObjectInfo : MonoBehaviour

{
    private TextMesh dispInfoMineralAmount;
    private TextMesh dispInfoMineralType;

    private GameObject selectedObject;
    private int mineralAmount;
    private bool interactableCheck;

    private bool sameCheck;
    private GameObject sameObject = null;
    private Vector3 interactableMineralDisplayPos;
    private Quaternion rotation = Quaternion.identity;
    private GameObject interactableVisual;

    private Vector3 currentCameraPos;
    private Vector3 initialVisualPos;
    private Vector3 vectorDifference;

    private void Start()
    {
        getInfoComponents();
    }


    private void Update()
    {
        checkForIntertacbleTag();
        updateInfoTextComponents();
        checkForSameInteractableObject();
        updateInfoVisualComponents();
        instnatiatedObjectTransform();

    }


    private void getInfoComponents()
    {

        //Get the Text Components
        dispInfoMineralAmount = GameObject.Find("interactableInfoDispMineralAmount").GetComponent<TextMesh>();
        dispInfoMineralType = GameObject.Find("interactableInfoDispMineralType").GetComponent<TextMesh>();

        //Get the placeholder component and its position 
        interactableVisual = GameObject.Find("placeHolderInteratableVisual");
        interactableMineralDisplayPos = interactableVisual.transform.localPosition;

        //Get the cameras position and find the difference between the camera position and the placeholder position
        currentCameraPos = GameObject.Find("Camera").GetComponent<CameraController>().CurrentPos;
        initialVisualPos = interactableMineralDisplayPos;
        vectorDifference = initialVisualPos - currentCameraPos;


    }


    private void checkForIntertacbleTag()
    {
        //Get the current selected object from the "userController" Script
        selectedObject = GameObject.Find("userController").GetComponent<userControls>().SelectedObject;

        //If the selected object has tag "Minera;")
        if (selectedObject.tag == "Mineral")
        {

            
            interactableCheck = true;
            
        }
        else
        {
            interactableCheck = false;
        }

        
    }

    private void updateInfoTextComponents()
    {
        if (interactableCheck == true)
        {
            //Get "MineralAmount" of the selected object from the "mineralAttributes" script 
            mineralAmount = selectedObject.GetComponent<mineralAttributes>().MineralAmount;

            //Change first text component to read "MineralAmount" 
            dispInfoMineralAmount.text = mineralAmount.ToString();



            switch (selectedObject.name)
            {
                case "material1(Clone)":
                    dispInfoMineralType.text = "Its Green Bitch";
                    break;
                case "material2(Clone)":
                    dispInfoMineralType.text = "Its Blue Bitch";
                    break;
                case "material3(Clone)":
                    dispInfoMineralType.text = "Its Yellow Bitch";
                    break;
                case "material4(Clone)":
                    dispInfoMineralType.text = "Its Grey (UK Translation: Gray) Bitch";
                    break;
                case "material5(Clone)":
                    dispInfoMineralType.text = "Its Orange Bitch";
                    break;
            }

        }

        else
        {
            //Changes text components to nothing when none of the above cases are met
            dispInfoMineralAmount.text = "";
            dispInfoMineralType.text = "";
        }



    }

    private void checkForSameInteractableObject() 
    //A visual graphic will appear on screen when an object is selected. But, the player will be changing selected objects. 
    //So, it is neccessary to check if the selected object has changed

    {

        //If "sameObject" is NOT equal to the selected object
          if(sameObject != selectedObject)
            {

            //samCheck is false
            //make "sameObject" equal to the selected object for the next check
                sameObject = selectedObject;
                sameCheck = false;
            
                
                 
            }

          else
            {
                sameCheck = true;

            }
         
    }

    private void updateInfoVisualComponents()
    {




        if (interactableCheck == true)
        {

            if (sameCheck == false)
            {
                Destroy(interactableVisual);
                interactableVisual = Instantiate(selectedObject, interactableMineralDisplayPos, rotation);
                interactableVisual.name = "InstantiatedInteractableVisual";

                //Strange bug instantiates the "Floor" Component on game start.
                //the instatiated Floor is destroyed after failing the interactable check

                interactableVisual.GetComponent<MeshRenderer>().enabled = true;

                Vector3 interactableScale = interactableVisual.transform.localScale;
                interactableScale = new Vector3(interactableScale.x / 2f, interactableScale.y / 2f, interactableScale.z / 2f);
                interactableVisual.transform.localScale = interactableScale;

                interactableVisual.transform.Rotate(55, 0, 0);

                interactableVisual.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            }
        }

        if (interactableCheck == false)
        {
            interactableVisual.GetComponent<MeshRenderer>().enabled = false;
        }

    }


    private void instnatiatedObjectTransform()
    {
        if(interactableCheck == true)
        {

             currentCameraPos = GameObject.Find("Camera").GetComponent<CameraController>().CurrentPos;
             interactableVisual.transform.localPosition = currentCameraPos + vectorDifference;
             interactableVisual.transform.Rotate(0, 6 * Time.deltaTime, 0, Space.Self);

        }

    }

}