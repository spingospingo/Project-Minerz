using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mineralDisplay : MonoBehaviour
{

    private Text mat1;
    private Text mat2;
    private Text mat3;
    private Text mat4;
    private Text mat5;
    

    private void Awake()
    {
        mat1 = GameObject.Find("Mat1").GetComponent<Text>();
        mat2 = GameObject.Find("Mat2").GetComponent<Text>();
        mat3 = GameObject.Find("Mat3").GetComponent<Text>();
        mat4 = GameObject.Find("Mat4").GetComponent<Text>();
        mat5 = GameObject.Find("Mat5").GetComponent<Text>();
    }

    private void Update()
    {
        mat1.text = " Mat1";

        mat2.text = " Mat2";

        mat3.text = " Mat3";

        mat4.text = " Mat4";

        mat5.text = " Mat5";

    }

   
 

}
