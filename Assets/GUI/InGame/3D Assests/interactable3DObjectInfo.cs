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
    private Vector3 interactableMineralDisplayPos = new Vector3(-12.31f, 7.97f, -10.44f);
    private Quaternion rotation = Quaternion.identity;
    private GameObject interactableVisual;
    private GameObject camera;

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
        

    }



    private void getInfoComponents()
    {
        dispInfoMineralAmount = GameObject.Find("interactableInfoDispMineralAmount").GetComponent<TextMesh>();
        dispInfoMineralType = GameObject.Find("interactableInfoDispMineralType").GetComponent<TextMesh>();

        interactableVisual = GameObject.Find("placeHolderInteratableVisual");

        camera = GameObject.Find("Camera");
    }


    private void checkForIntertacbleTag()
    {
        selectedObject = GameObject.Find("userController").GetComponent<userControls>().SelectedObject;
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
            mineralAmount = selectedObject.GetComponent<mineralAttributes>().MineralAmount;

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
            dispInfoMineralAmount.text = "";
            dispInfoMineralType.text = "";
        }



    }

    private void checkForSameInteractableObject()
    {
        if (interactableCheck == true)
        {
          if(sameObject != selectedObject)
            {
                sameObject = selectedObject;
                sameCheck = false; 
            }

          else
            {
                sameCheck = true;

            }
        }

        else
        {
            sameCheck = true;
        }      
    }

    private void updateInfoVisualComponents()
    {



       

        if (sameCheck == false)
        {
            Destroy(interactableVisual);
            interactableVisual = Instantiate(selectedObject, interactableMineralDisplayPos, rotation);
            //Strange bug instantiates the "Floor" Component on game start.
            //the instatiated Floor is destroyed after failing the interactable check

            interactableVisual.transform.Rotate(55, 0, 0);
           

        }


 

        if (sameCheck == true)

        {
            if (interactableCheck == true)
            {
                interactableVisual.transform.Rotate(0, 6*Time.deltaTime, 0, Space.Self);

                
            }

        }


        if (interactableCheck == false)
        {
            Destroy(interactableVisual);
        }

        Debug.Log(sameCheck);
    }

}