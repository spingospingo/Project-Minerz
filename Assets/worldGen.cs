<<<<<<< Updated upstream:Assets/worldGen.cs
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldGen : MonoBehaviour
{
 /*----------------------------READ ME------------------------------
  * The density of the rocks and minerals generated are directly
  * correlated to their spawn chances. Chanes are expressed in %. */
    private float smallRockChance = 60;
    private float bigRockChance = 5;
    private float mat1Chance = 0.5f;
    private float mat2Chance = 0.5f;
    private float mat3Chance = 0.5f;
    private float mat4Chance = 0.5f;
    private float mat5Chance = 0.5f;
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
    public GameObject mat1, mat2, mat3, mat4, mat5;

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
                float roll = Random.Range(1f, 100f);
                Debug.Log(roll);
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
                else if (roll <= smallRockChance + bigRockChance
                    + mat1Chance)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z);
                    if (!Physics.CheckSphere(spawnPos, 0.5f))
                    {
                        Instantiate(mat1, spawnPos, rotation);
                        //move 1 extra to avoid uselessly iterating
                        x++;
                    }
                }
                else if (roll <= smallRockChance + bigRockChance
                    + mat1Chance + mat2Chance)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z);
                    if (!Physics.CheckSphere(spawnPos, 0.5f))
                    {
                        Instantiate(mat2, spawnPos, rotation);
                        //move 1 extra to avoid uselessly iterating
                        x++;
                    }
                }
                else if (roll <= smallRockChance + bigRockChance
                    + mat1Chance + mat2Chance + mat3Chance)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z);
                    if (!Physics.CheckSphere(spawnPos, 0.5f))
                    {
                        Instantiate(mat3, spawnPos, rotation);
                        //move 1 extra to avoid uselessly iterating
                        x++;
                    }
                }
                else if (roll <= smallRockChance + bigRockChance
                    + mat1Chance + mat2Chance + mat3Chance
                    + mat4Chance)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z);
                    if (!Physics.CheckSphere(spawnPos, 0.5f))
                    {
                        Instantiate(mat4, spawnPos, rotation);
                        //move 1 extra to avoid uselessly iterating
                        x++;
                    }
                }
                else if (roll <= smallRockChance + bigRockChance
                    + mat1Chance + mat2Chance + mat3Chance
                    + mat4Chance + mat5Chance)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z);
                    if (!Physics.CheckSphere(spawnPos, 0.5f))
                    {
                        Instantiate(mat5, spawnPos, rotation);
                        //move 1 extra to avoid uselessly iterating
                        x++;
                    }
                }
            }
        }
    }
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldGen : MonoBehaviour
{
 /*----------------------------READ ME------------------------------
  * The density of the rocks and minerals generated are directly
  * correlated to their spawn chances. Chanes are expressed in %. */
    private float smallRockChance = 60;
    private float bigRockChance = 5;
    private float mat1Chance = 0.5f;
    private float mat2Chance = 0.5f;
    private float mat3Chance = 0.5f;
    private float mat4Chance = 0.5f;
    private float mat5Chance = 0.5f;
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
    public GameObject mat1, mat2, mat3, mat4, mat5;

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
                float roll = Random.Range(1f, 100f);
                Debug.Log(roll);
                //1-5
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
                //5 - 65
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
                //65 - 65.5
                else if (roll <= smallRockChance + bigRockChance
                    + mat1Chance)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z);
                    if (!Physics.CheckSphere(spawnPos, 0.5f))
                    {
                        Instantiate(mat1, spawnPos, rotation);
                        //move 1 extra to avoid uselessly iterating
                        x++;
                    }
                }
                //65.5 - 66
                else if (roll <= smallRockChance + bigRockChance
                    + mat1Chance + mat2Chance)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z);
                    if (!Physics.CheckSphere(spawnPos, 0.5f))
                    {
                        Instantiate(mat2, spawnPos, rotation);
                        //move 1 extra to avoid uselessly iterating
                        x++;
                    }
                }
                //66 - 66.5
                else if (roll <= smallRockChance + bigRockChance
                    + mat1Chance + mat2Chance + mat3Chance)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z);
                    if (!Physics.CheckSphere(spawnPos, 0.5f))
                    {
                        Instantiate(mat3, spawnPos, rotation);
                        //move 1 extra to avoid uselessly iterating
                        x++;
                    }
                }
                //66.5 - 67
                else if (roll <= smallRockChance + bigRockChance
                    + mat1Chance + mat2Chance + mat3Chance
                    + mat4Chance)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z);
                    if (!Physics.CheckSphere(spawnPos, 0.5f))
                    {
                        Instantiate(mat4, spawnPos, rotation);
                        //move 1 extra to avoid uselessly iterating
                        x++;
                    }
                }
                //67 - 67.5
                else if (roll <= smallRockChance + bigRockChance
                    + mat1Chance + mat2Chance + mat3Chance
                    + mat4Chance + mat5Chance)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z);
                    if (!Physics.CheckSphere(spawnPos, 0.5f))
                    {
                        Instantiate(mat5, spawnPos, rotation);
                        //move 1 extra to avoid uselessly iterating
                        x++;
                    }
                }
            }
        }
    }
}
>>>>>>> Stashed changes:Assets/mainGame/worldGen.cs
