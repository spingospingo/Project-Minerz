using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mineralDisplay3D : MonoBehaviour
{
    private TextMesh mat1, mat2, mat3, mat4, mat5;
    private playerBehavior player;
    private GameObject mat; 


    private void Start()
    {
        getMatValues();
        getMatTextComponent();

    }

    private void OnGUI()
    {
        
        convertMatIntToString();
    }


    private void getMatValues()
    {
        mat = gameObject;
        player = GameObject.Find("Player").GetComponent<playerBehavior>();
    }

    private void getMatTextComponent()
    {


        mat1 = GameObject.Find("Mat13D").GetComponent<TextMesh>();
        mat2 = GameObject.Find("Mat23D").GetComponent<TextMesh>();
        mat3 = GameObject.Find("Mat33D").GetComponent<TextMesh>();
        mat4 = GameObject.Find("Mat43D").GetComponent<TextMesh>();
        mat5 = GameObject.Find("Mat53D").GetComponent<TextMesh>();

        
    }


    private void convertMatIntToString()
    {
        mat1.text = player.Mat1Inv.ToString();
        mat2.text = player.Mat2Inv.ToString();
        mat3.text = player.Mat3Inv.ToString();
        mat4.text = player.Mat4Inv.ToString();
        mat5.text = player.Mat5Inv.ToString();

    }
}
