using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineralAttributes : MonoBehaviour
{
    private Material mineralType;

    private int mineralAmount;
    public int MineralAmount  
    {
        get { return mineralAmount; }
        set
        {

        }

    }


    void Awake()
    {
        mineralAmountScript();
        mineralTypeScript(); 
    }

    void Update()
    {
        mineralAmountUpdateScript();
    }


        private void mineralAmountScript()
        {
            mineralAmount = Random.Range(400, 500);
        }


        private void mineralTypeScript()
        {
            mineralType = GetComponent<Renderer>().material;
            Debug.Log(mineralType);
        } 
    
        private void mineralAmountUpdateScript() //This Method will be used to "mine" from the game object, for now it is used to test the mineral amount during runtime
        {

            bool testbool = true;

                if (testbool == true)
                {
                    mineralAmount--;
                }
                
                if (testbool == false)
                {
                    mineralAmount++;
                }

                if (mineralAmount > 499)
                 {
                    testbool = true;
                 }

                if (mineralAmount < 401)
                {
                  testbool = false;
                }

        }


    }
