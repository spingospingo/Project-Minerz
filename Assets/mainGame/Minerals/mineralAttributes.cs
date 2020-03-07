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
        
    }

    void Update()
    {
       
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
