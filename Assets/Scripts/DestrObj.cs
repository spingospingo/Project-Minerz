using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrObj : MonoBehaviour
{

    public float health;
    public float playerAttack = 1;
    public GameObject destrObj;

    // Update is called once per frame
    void Update()
    {
        //RIGHT CLICK TO DESTROY
        if (Input.GetMouseButtonDown(1))
        {
            this.transform.SendMessageUpwards("GetDamage", playerAttack, SendMessageOptions.DontRequireReceiver);
        }
    }
   
   //THIS WILL CHANGE
    public void GetDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameObject destroy_ob = Instantiate(destrObj, this.transform.position, this.transform.rotation) as GameObject;
            Destroy(gameObject);
        }

    }
    // NEED TO ADD STILL -Rock layer, only interact with rock layer
}
