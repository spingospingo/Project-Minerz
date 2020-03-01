using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldGen : MonoBehaviour
{
    /*----------------------------READ ME------------------------------
     * The density of the rocks and minerals generated are directly
     * correlated to their spawn chances. Chanes are expressed in %. */
       private int smallRockChance = 60;
       private int bigRockChance = 5;
    /* Physics.CheckSphere() spawns a sphere at the specified location.
     * If that sphere contacts any hitboxes, it returns true. This is
     * used to check for "dead zones." Dead zones are areas where this
     * script will NOT place a block. The main "+" path has a collider 
     * box that only interacts with this function to line out the static 
     * deadzone. Dynamic deadzones are simply locations that already
     * have an object on it.
     *---------------------------------------------------------------*/

    public GameObject bigRock;
    public GameObject smallRock;

    //limits are the starting edges of the board.
    private int xLim = -80;
    private int zLim = 80;

    /*a rotation is needed because Instantiate() accepts Vector3's
    only with associated Quaternions*/
    private Quaternion rotation = Quaternion.identity;
    private Vector3 offset = new Vector3(0, 1, 0);

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
            for (int x = xLim; x < -xLim + 1; x++)
            {
                int roll = Random.Range(1, 100);
                if (roll <= bigRockChance)
                {
                    Vector3 spawnPos = new Vector3(x + 1, 1, z - 1);
                    //check if block is already placed AND not at map border
                    if (!Physics.CheckSphere(spawnPos + offset, 1f)
                        && (spawnPos.x < xLim)
                        && (spawnPos.z > -zLim))
                    {
                        Instantiate(bigRock, spawnPos, rotation);
                        /*move 2 extra, otherwise will find object
                        that was just placed. Useless.*/
                        x += 2;
                    }
                    //if (spawnPos.x >= 80)
                    //{
                    //    Debug.Log("This is it pardner");
                    //}
                }
                else if (roll <= smallRockChance + bigRockChance)
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
