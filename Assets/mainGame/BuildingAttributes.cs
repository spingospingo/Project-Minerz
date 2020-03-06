using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAttributes : MonoBehaviour
{

//************HEALTH**************************************************************//
    private bool BoOol = true;
    private float startingHealth = 1000f;
    private float scalingConstant = 1.0f;
    private int health;
    public int Health
    {
        get { return health; }
        set { }

    }

    void Start()
    {
        health = (int)Math.Round(/*getDay() **/ scalingConstant * startingHealth);
    }

   /* void FixedUpdate()
    {
        if (health <= 0)
        {
            //remove object from scene after 1 second
            Destroy(gameObject, 1);
            Debug.Log("Blargh. I, " + gameObject.name + ", am dead.");
        }
    }
    */
    //call this from attacking objects to do damage to enemy
    public void receiveDamage(int damage)
    {
        health -= damage;
    }

    void Update()
    {
        if(health == 1000)
        {
            BoOol = true;
        }
       
        if(health == 0)
        {
            BoOol = false;
        }

        if(BoOol == true)
        {
            health--;
        }

        if(BoOol == false)
        {
            health++;
        }
    }
    //private float getDay()
    //{
    //    GameObject dayTracker = GameObject.Find("dayTracker");
    //    return dayTracker.day;
    //}

    //************END - HEALTH**************************************************************//





 





















}
