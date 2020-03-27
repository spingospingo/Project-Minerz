using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaderValueChanger : MonoBehaviour
{
    private Material materialShader;


    private playerBehavior player;
    private GameObject Plane;
    private float matInv;

    private float maxFloatRippleSpeed, maxFloatRippleDensity, minFloatRippleSlimness;
    private float floatRippleSpeed, floatRippleDensity, floatRippleSlimness;
    private int maxMat = 100; //placeholder

    private Vector3 vectorPosition, vectorScale;
    private float deviationValue;
    private Vector3 maxVectorCheck, initialVectorPosition;




    private void Start()
    {
        getMatValues();
        getPlane();
        getPlaneShader();
        setShaderValueLimits();
        reloadShaderValues();
    }

    private void Update()
    {
        setMatSpecificPlaneShaderValues();
        updatePlaneVectorValues();

    }










    private void getMatValues()
    {
        player = GameObject.Find("Player").GetComponent<playerBehavior>();
    }

    private void getPlane()
    {
        Plane = gameObject;
        vectorPosition = Plane.transform.localPosition;
        vectorScale = Plane.transform.localScale;

        initialVectorPosition = Plane.transform.localPosition;
        
    }

    private void getPlaneShader()
    {
        materialShader = gameObject.GetComponent<Renderer>().sharedMaterial;

    }


    private void setShaderValueLimits()
    {
        //for reference 
        //speed = 1
        //Density = 4
        //Slimness = 3

        maxFloatRippleSpeed = 16f;
        maxFloatRippleDensity = 7f;
        minFloatRippleSlimness = 1f;

        floatRippleSpeed = materialShader.GetFloat("Vector1_473873AB");
        floatRippleDensity = materialShader.GetFloat("Vector1_B7129893");
        floatRippleSlimness = materialShader.GetFloat("Vector1_B16D280");



    }


    private void reloadShaderValues()
    {
        materialShader.SetFloat("Vector1_473873AB", 1);
        materialShader.SetFloat("Vector1_B7129893", 4);
        materialShader.SetFloat("Vector1_B16D280", 3);

        materialShader.SetFloat("Vector1_473873AB2", 1);
        materialShader.SetFloat("Vector1_B71298932", 4);
        materialShader.SetFloat("Vector1_B16D2802", 3);

        materialShader.SetFloat("Vector1_473873AB3", 1);
        materialShader.SetFloat("Vector1_B71298933", 4);
        materialShader.SetFloat("Vector1_B16D2803", 3);

        materialShader.SetFloat("Vector1_473873AB4", 1);
        materialShader.SetFloat("Vector1_B71298934", 4);
        materialShader.SetFloat("Vector1_B16D2804", 3);

        materialShader.SetFloat("Vector1_473873AB5", 1);
        materialShader.SetFloat("Vector1_B71298935", 4);
        materialShader.SetFloat("Vector1_B16D2805", 3);


    }
    private void setMatSpecificPlaneShaderValues()
    {

        

        switch (Plane.name)
        {
            case "visualMat1":
                materialShader.SetColor("Color_9E5F7169", new Color32(43, 243, 14, 255));
                matInv = player.Mat1Inv;

                materialShader.SetFloat("Vector1_473873AB",(maxFloatRippleSpeed *matInv)/maxMat);
                materialShader.SetFloat("Vector1_B7129893",(maxFloatRippleDensity*matInv)/maxMat);
                materialShader.SetFloat("Vector1_B16D280",3 - (minFloatRippleSlimness*matInv)/maxMat);

                break;

            case "visualMat2":
                materialShader.SetColor("Color_9E5F7169", new Color32(67,9 ,149 , 255));
                matInv = player.Mat2Inv;

                materialShader.SetFloat("Vector1_473873AB2", (maxFloatRippleSpeed * matInv) / maxMat);
                materialShader.SetFloat("Vector1_B71298932", (maxFloatRippleDensity * matInv) / maxMat);
                materialShader.SetFloat("Vector1_B16D2802", 3 - (minFloatRippleSlimness * matInv) / maxMat);

                break;

            case "visualMat3":
                materialShader.SetColor("Color_9E5F7169", new Color32(244, 179, 14, 255));
                matInv = player.Mat3Inv;

                materialShader.SetFloat("Vector1_473873AB3", (maxFloatRippleSpeed * matInv) / maxMat);
                materialShader.SetFloat("Vector1_B71298933", (maxFloatRippleDensity * matInv) / maxMat);
                materialShader.SetFloat("Vector1_B16D2803", 3 - (minFloatRippleSlimness * matInv) / maxMat);

                break;

            case "visualMat4":
                materialShader.SetColor("Color_9E5F7169", new Color32(108, 118, 106, 255));
                matInv = player.Mat4Inv;

                materialShader.SetFloat("Vector1_473873AB4", (maxFloatRippleSpeed * matInv) / maxMat);
                materialShader.SetFloat("Vector1_B71298934", (maxFloatRippleDensity * matInv) / maxMat);
                materialShader.SetFloat("Vector1_B16D2804", 3 - (minFloatRippleSlimness * matInv) / maxMat);

                break;

            case "visualMat5":
                materialShader.SetColor("Color_9E5F7169", new Color32(202, 124, 102, 255));
                matInv = player.Mat5Inv;

                materialShader.SetFloat("Vector1_473873AB5", (maxFloatRippleSpeed * matInv) / maxMat);
                materialShader.SetFloat("Vector1_B71298935", (maxFloatRippleDensity * matInv) / maxMat);
                materialShader.SetFloat("Vector1_B16D2805", 3 - (minFloatRippleSlimness * matInv) / maxMat);

                break;
        }

    }



    private void updatePlaneVectorValues()
    {

        

        maxVectorCheck.x = initialVectorPosition.x + 1.252f;

        if (maxVectorCheck.x >= Plane.transform.position.x)
        {
            Debug.Log(matInv);

            Vector3 vectorPositionChange = new Vector3(((1.252f*matInv)/maxMat), 0, 0);
            Vector3 vectorScaleChange = new Vector3(0, ((1.252f*matInv)/maxMat) * .999905f, 0);

            Plane.transform.localPosition = vectorPosition + vectorPositionChange;
            Plane.transform.localScale = vectorScale + vectorScaleChange;



        }
        
    }

}
