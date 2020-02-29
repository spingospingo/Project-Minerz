using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldGen : MonoBehaviour
{
    public GameObject bigRock;
    public GameObject smallRock;

    //limits are the starting edges of the board.
    private int xLim = -80;
    private int zLim = 80;

    /*a rotation is needed because Instantiate() accepts Vector3's
    only with associated Quaternions*/
    private Quaternion rotation = Quaternion.identity;
    private Vector3 offset = new Vector3(-1, 0, 0);

    void Start()
    {
        placeRocks();
    }

    private void placeRocks()
    {
        //iterate over the z-axis of plane
        for (int z = zLim; z > -zLim - 1; z-=2)
        {
            //fill in every x-axis line
            for (int x = xLim; x < -xLim; x++)
            {
                int roll = Random.Range(1, 100);
                //big rock = 5% chance of spawning
                if (roll <= 5)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z - 1);
                    //check if block is already placed
                    if (!Physics.CheckSphere(spawnPos + offset, 0.9f))
                    {
                        Instantiate(bigRock, spawnPos, rotation);
                        /*move 2 extra, otherwise will check for object
                        that was just placed. Useless.*/
                        x += 2;
                    }
                }
                //small rock = 50 - 5 = 45% chance of spawning
                else if (roll <= 50)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z);
                    if (!Physics.CheckSphere(spawnPos, 0.5f))
                    {
                        Instantiate(smallRock, spawnPos, rotation);
                        //move 1 extra to avoid uselessly iterating
                        x++;
                    }
                }
            }
        }
    }
}
