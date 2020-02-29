using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldGen : MonoBehaviour
{
    public GameObject bigRock;
    public GameObject smallRock;
    //private bool smallFlag = false;
    //private bool bigFlag = false;
    private int xLim = -80;
    private int zLim = 80;
    private Quaternion rotation = Quaternion.identity;

    void Start()
    {
        placeRocks();
    }

    private void placeRocks()
    {
        for (int z = zLim; z > -zLim - 1; z-=2)
        {
            for (int x = xLim; x < -xLim; x++)
            {
                int roll = Random.Range(1, 100);
                if (roll <= 5)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z - 1);
                    if (!Physics.CheckSphere(spawnPos, 0.5f))
                    {
                        Instantiate(bigRock, spawnPos, rotation);
                        //bigFlag = true;
                        //smallFlag = false;
                        x += 2;
                    }
                }
                else if (roll <= 50)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z);
                    if (!Physics.CheckSphere(spawnPos, 0.5f))
                    {
                        Instantiate(smallRock, spawnPos, rotation);
                        //bigFlag = false;
                        //smallFlag = true;
                        x++;
                    }
                }
                else
                {
                    //bigFlag = false;
                    //smallFlag = false;
                }
            }
        }
    }
}
