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

    void Start()
    {
        guiGetGUIComponent();
    }

    void Update()
    {
        guiGetAttributeUpdate(); //for some reason this script does not work in onGUI()
    }

    private void guiGetGUIComponent()
    {
        //find the text box component 
        topText = GameObject.Find("TopText").GetComponent<Text>();
        topText.text = " ";

        imageSelect = GameObject.Find("matFrameWorkImage");
        imageSelect.gameObject.SetActive(false);
    }

    private void guiGetAttributeUpdate()
    {
        //if no interactable object is selected (ground)
        if (GameObject.Find("Player").GetComponent<playerBehavior>().ObjectType == "none")
        {
            topText.text = " ";
            imageSelect.gameObject.SetActive(false);
        }
        //if mineral is selected
        else if (GameObject.Find("Player").GetComponent<playerBehavior>().ObjectType == "mineral")
        {
            //send mineral attribute values to gui text
            mineralAmount = GameObject.Find("Player").GetComponent<playerBehavior>()
                .SelectedObject.GetComponent<mineralAttributes>().MineralAmount;
            topText.text = mineralAmount.ToString();

            objectName = GameObject.Find("Player").GetComponent<playerBehavior>().SelectedObject.name;
            switch(objectName)
            {
                case "material1(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = Color.green;
                    break;
                case "material5(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = Color.blue;
                    break;
                case "material2(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = new Color(128f / 255f, 0f, 128f / 255f);
                    break;
                case "material4(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = Color.red;
                    break;
                case "material3(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = Color.yellow;
                    break;
            }
        }
        else if (GameObject.Find("Player").GetComponent<playerBehavior>().ObjectType == "rock")
        {
            //rock stuff
        }
    }
}

