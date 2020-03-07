using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interactableObjectInfoGUI : MonoBehaviour
{
    private Text topText;
    private int playerSelectInfo;

    void Start()
    {
    topText = GameObject.Find("TopText").GetComponent<Text>();
    
    }
    void Update()
    {
     if(GameObject.Find("Player").GetComponent<Movement>().AttributeType == 0 )
     {
            playerSelectInfo = GameObject.Find("Player").GetComponent<Movement>().guiMineralAmount;
            topText.text = playerSelectInfo.ToString();
     }
        
    }


}
