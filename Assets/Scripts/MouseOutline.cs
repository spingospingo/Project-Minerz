using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOutline : MonoBehaviour
{
    Shader shader1;
    Shader shader2;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        //CAN EDIT FOR DIFFERNT OUTLINES
        rend = GetComponent<Renderer>();
        shader1 = Shader.Find("Diffuse");
        shader2 = Shader.Find("Custom/Outline");
       
    }
    
    void OnMouseEnter()
    {
        // Change shader of GameObject
        if (rend.material.shader == shader1)
        {
            rend.material.shader = shader2;
        }
        else
        {
            rend.material.shader = shader2;
        }
    }
    void OnMouseExit()
    {
        // Reset the shader of the GameObject back to normal
        if (rend.material.shader == shader2)
        {
            rend.material.shader = shader1;
        }
        else 
        {
            rend.material.shader = shader1;
        }
        
    }

}
