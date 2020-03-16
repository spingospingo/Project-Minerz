using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mineralDisplay : MonoBehaviour
{
    private Text mat1, mat2, mat3, mat4, mat5;
    private playerBehavior player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<playerBehavior>();

        mat1 = GameObject.Find("Mat1").GetComponent<Text>();
        mat2 = GameObject.Find("Mat2").GetComponent<Text>();
        mat3 = GameObject.Find("Mat3").GetComponent<Text>();
        mat4 = GameObject.Find("Mat4").GetComponent<Text>();
        mat5 = GameObject.Find("Mat5").GetComponent<Text>();
    }

    private void OnGUI()
    {
        mat1.text = player.Mat1Inv.ToString();
        mat2.text = player.Mat2Inv.ToString();
        mat3.text = player.Mat3Inv.ToString();
        mat4.text = player.Mat4Inv.ToString();
        mat5.text = player.Mat5Inv.ToString();
    }
}
