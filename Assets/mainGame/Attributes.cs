using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    private float startingHealth = 100f;
    private float scalingConstant = 1.0f;
    private int health;

    void Start()
    {
        health = (int)Math.Round(/*getDay() **/ scalingConstant * startingHealth);
    }

    void FixedUpdate()
    {
        if (health <= 0)
        {
            //remove object from scene after 1 second
            Destroy(gameObject, 1);
            Debug.Log("Blargh. I, " + gameObject.name + ", am dead.");
        }
    }

    //call this from attacking objects to do damage to enemy
    public void receiveDamage(int damage)
    {
        health -= damage;
    }

    //private float getDay()
    //{
    //    GameObject dayTracker = GameObject.Find("dayTracker");
    //    return dayTracker.day;
    //}
}
