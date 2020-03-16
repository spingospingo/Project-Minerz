using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactableObjectInfoGUI : MonoBehaviour
{
    private Text topText;
    private GameObject imageSelect;
    private int mineralAmount;
    private string objectName;
    private Color mat1color, mat2color, mat3color, mat4color, mat5color;

    void Start()
    {
        mat1color = GameObject.Find("mat1Image").GetComponent<Image>().color;
        mat2color = GameObject.Find("mat2Image").GetComponent<Image>().color;
        mat3color = GameObject.Find("mat3Image").GetComponent<Image>().color;
        mat4color = GameObject.Find("mat4Image").GetComponent<Image>().color;
        mat5color = GameObject.Find("mat5Image").GetComponent<Image>().color;

        getGUIComponent();
    }

    void Update()
    {
        setSelectedObjectGUI(); 
    }

    private void getGUIComponent()
    {
        //find the text box component 
        topText = GameObject.Find("TopText").GetComponent<Text>();
        topText.text = " ";

        imageSelect = GameObject.Find("matFrameWorkImage");
        imageSelect.gameObject.SetActive(false);
    }

    private void setSelectedObjectGUI()
    {
        GameObject selectedObject = GameObject.Find("userController").GetComponent<userControls>().SelectedObject;
        //if mineral is selected
        if (selectedObject.tag == "Mineral")
        {
            //send mineral attribute values to gui text
            mineralAmount = selectedObject.GetComponent<mineralAttributes>().MineralAmount;
            topText.text = mineralAmount.ToString();

            objectName = selectedObject.name;
            switch(objectName)
            {
                case "material1(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = mat1color;
                    break;
                case "material2(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = mat2color;
                    break;
                case "material3(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = mat3color;
                    break;
                case "material4(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = mat4color;
                    break;
                case "material5(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = mat5color;
                    break;
            }
        }
        //if rock is selected
        else if (selectedObject.tag == "Rock")
        {
            //placeholder code, simply "deselects" an object according to the ui
            topText.text = " ";
            imageSelect.gameObject.SetActive(false);
        }
        //if no interactable object is selected (ground)
        else
        {
            topText.text = " ";
            imageSelect.gameObject.SetActive(false);
        }
    }
}

