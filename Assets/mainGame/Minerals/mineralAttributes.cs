using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineralAttributes : MonoBehaviour
{
    private int mineralAmount;
    public int MineralAmount  
    {
        get { return mineralAmount; }
        set { }
    }

    void Start()
    {
        mineralGen();
    }

    private void mineralGen()
    {
        mineralAmount = Random.Range(9000, 11000);
    }

    //player sends mine() to this object
    public int mine(int value)
    {
        if (mineralAmount > value)
        {
            //subtract mine amount from mineral node
            mineralAmount -= value;
            //give miner the amount mined
            return value;
        }
        else if (mineralAmount <= 0)
        {
            return 0;
        }
        else //if there isn't enough to give to miner
        {
            int tempAmount = mineralAmount;
            mineralAmount = 0;
            return tempAmount;
        }
    }
}
