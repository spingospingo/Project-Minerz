﻿using System.Collections;
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
        //if mineral is selected
        if (GameObject.Find("Player").GetComponent<playerBehavior>().SelectedObject.tag == "Mineral")
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
                case "material2(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = new Color(128f / 255f, 0f, 128f / 255f);
                    break;
                case "material3(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = Color.yellow;
                    break;
                case "material4(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = Color.red;
                    break;
                case "material5(Clone)":
                    imageSelect.gameObject.SetActive(true);
                    imageSelect.GetComponent<Image>().color = Color.blue;
                    break;
            }
        }
        //if rock is selected
        else if (GameObject.Find("Player").GetComponent<playerBehavior>().SelectedObject.tag == "Rock")
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

