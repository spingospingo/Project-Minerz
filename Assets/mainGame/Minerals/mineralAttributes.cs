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

    void Start()
    {
        mineralAmountScript();
        //mineralTypeScript(); 
    }

    void Update()
    {
        //mineralAmountUpdateScript();
    }

    private void mineralAmountScript()
    {
        mineralAmount = Random.Range(9000, 11000);
    }

    //private void mineralTypeScript()
    //{
    //    mineralType = GetComponent<Renderer>().material;
    //    Debug.Log(mineralType);
    //}

    //for test the mineral amount during runtime
    private void mineralAmountUpdateScript() 
    {
        bool limitBool = true;

        if (limitBool == true)
        {
            mineralAmount--;
        }
        else
        {
            mineralAmount++;
        }

        if (mineralAmount > 9999)
        {
            limitBool = true;
        }
        else if (mineralAmount < 1)
        {
            limitBool = false;
        }
    }
    
    //player sends mine() to this object
    public int mine(int value)
    {
        mineralAmount -= value;
        return value;
    }
}
