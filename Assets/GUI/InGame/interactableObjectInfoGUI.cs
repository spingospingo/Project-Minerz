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
        //if variable AttributeType = -1 (no attribute type)
        if (GameObject.Find("Player").GetComponent<playerBehavior>().AttributeType == -1)
        {
            topText.text = " ";
            imageSelect.gameObject.SetActive(false);
        }

        //if variable Attributetype = 0 (mineral attribute type)
        if (GameObject.Find("Player").GetComponent<playerBehavior>().AttributeType == 0)
        {
            //send mineral attribute values to gui text
            playerSelectInfo = GameObject.Find("Player").GetComponent<playerBehavior>().GuiMineralAmount;
            topText.text = playerSelectInfo.ToString();

            imageSelectInfo = GameObject.Find("Player").GetComponent<playerBehavior>().GuiTypeMineral;

            if (imageSelectInfo == "GreenMineral")
            {
                imageSelect.gameObject.SetActive(true);
                imageSelect.GetComponent<Image>().color = Color.green;
            }

            if (imageSelectInfo == "BlueMineral")
            {
                imageSelect.gameObject.SetActive(true);
                imageSelect.GetComponent<Image>().color = Color.blue;
            }

            if (imageSelectInfo == "PurpleMineral")
            {
                imageSelect.gameObject.SetActive(true);
                imageSelect.GetComponent<Image>().color = new Color(128f/255f, 0f, 128f/255f);
            }

            if (imageSelectInfo == "RedMineral")
            {
                imageSelect.gameObject.SetActive(true);
                imageSelect.GetComponent<Image>().color = Color.red;
            }

            if (imageSelectInfo == "YellowMineral")
            {
                imageSelect.gameObject.SetActive(true);
                imageSelect.GetComponent<Image>().color = Color.yellow;
            }
        }
    }
}

