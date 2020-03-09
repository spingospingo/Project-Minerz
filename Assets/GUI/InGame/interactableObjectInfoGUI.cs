using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactableObjectInfoGUI : MonoBehaviour
{
    private Text topText;
    private GameObject imageSelect;
    private int playerSelectInfo;
    private string imageSelectInfo;

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
        if (GameObject.Find("Player").GetComponent<playerBehavior>().AttributeType == "none")
        {
            topText.text = " ";
            imageSelect.gameObject.SetActive(false);
        }
        //if mineral is selected
        else if (GameObject.Find("Player").GetComponent<playerBehavior>().AttributeType == "mineral")
        {
            //send mineral attribute values to gui text
            playerSelectInfo = GameObject.Find("Player").GetComponent<playerBehavior>().GuiMineralAmount;
            topText.text = playerSelectInfo.ToString();

            imageSelectInfo = GameObject.Find("Player").GetComponent<playerBehavior>().GuiTypeMineral;

            switch(imageSelectInfo)
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
                //add case for smallRock
                //add case for bigRock
            }
        }
    }
}

