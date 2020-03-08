using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineralAttributes : MonoBehaviour
{
    //private Material mineralType;

    private int mineralAmount;
    public int MineralAmount  
    {
        get { return mineralAmount; }
        set { }
    }

    private string typeMineral;
    public string TypeMineral
    {
        get { return typeMineral;  }
        set { }
    }
    void Start()
    {
        mineralAmountScript();
        mineralTypeScript();
    }

    void Update()
    {
       
    }


    private void mineralTypeScript()
    {

        if(gameObject.name == "material1(Clone)")
        {
            typeMineral = "GreenMineral";
        }

        if (gameObject.name == "material5(Clone)")
        {
            typeMineral = "BlueMineral";
        }

        if (gameObject.name == "material2(Clone)")
        {
            typeMineral = "PurpleMineral";
        }

        if (gameObject.name == "material4(Clone)")
        {
            typeMineral = "RedMineral";
        }

        if (gameObject.name == "material3(Clone)")
        {
            typeMineral = "YellowMineral";
        }
    }


    private void mineralAmountScript()
    {
        mineralAmount = Random.Range(9000, 11000);
    }


    
    //player sends mine() to this object
    public int mine(int value)
    {
        mineralAmount -= value;
        return value;
    }
}
