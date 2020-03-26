using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mineralDisplay : MonoBehaviour
{
    private Text mat1, mat2, mat3, mat4, mat5;
    private playerBehavior player;
    private Slider mat1slider, mat2slider, mat3slider, mat4slider, mat5slider;
    private Image fill1slider, fill2slider, fill3slider, fill4slider, fill5slider;

    private float maxMat = 10; //placeholder value to give slider component a max value to use

    private void Awake()
    {
        getMatValues();
        getMatTextComponent();
        getMatSlider();

    }

    private void OnGUI()
    {
        changeMatSliderVisual();
        convertMatIntToString();
    }


    private void getMatValues()
    {
        player = GameObject.Find("Player").GetComponent<playerBehavior>();
    }

    private void getMatTextComponent()
    {
        mat1 = GameObject.Find("Mat1").GetComponent<Text>();
        mat2 = GameObject.Find("Mat2").GetComponent<Text>();
        mat3 = GameObject.Find("Mat3").GetComponent<Text>();
        mat4 = GameObject.Find("Mat4").GetComponent<Text>();
        mat5 = GameObject.Find("Mat5").GetComponent<Text>();
    }

    private void getMatSlider()
    {
        mat1slider = GameObject.Find("Mat1Slider").GetComponent<Slider>();
        mat2slider = GameObject.Find("Mat2Slider").GetComponent<Slider>();
        mat3slider = GameObject.Find("Mat3Slider").GetComponent<Slider>();
        mat4slider = GameObject.Find("Mat4Slider").GetComponent<Slider>();
        mat5slider = GameObject.Find("Mat5Slider").GetComponent<Slider>();

        fill1slider = mat1slider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
        fill2slider = mat2slider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
        fill3slider = mat3slider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
        fill4slider = mat4slider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
        fill5slider = mat5slider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>();
    }

    private void changeMatSliderVisual()
    {
        mat1slider.value = player.Mat1Inv / maxMat;
        fill1slider.color = new Color(43f/255f,140f/255f ,15f/255f , player.Mat1Inv / maxMat );

        mat2slider.value = player.Mat2Inv / maxMat;
        fill2slider.color = new Color(67f / 255f, 9f / 255f, 149f / 255f, player.Mat2Inv / maxMat);

        mat3slider.value = player.Mat3Inv / maxMat;
        fill3slider.color = new Color(244f / 255f, 179f / 255f, 14f / 255f, player.Mat3Inv / maxMat);

        mat4slider.value = player.Mat4Inv / maxMat;
        fill4slider.color = new Color(108f / 255f, 118f / 255f, 106f / 255f, player.Mat4Inv / maxMat);

        mat5slider.value = player.Mat5Inv / maxMat;
        fill5slider.color = new Color(202f / 255f, 124f / 255f, 102f / 255f, player.Mat5Inv / maxMat);
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
