﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DamageCircle : NetworkBehaviour
{
    public SphereCollider coll;
    public bool outOfZone = false;
    public int interval = 100;
    public int damage = 2;
    public int time=0;
    
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger in Zone: "+ other.gameObject);
        if (other.gameObject.name == coll.gameObject.name)
        {
            time = 0;
            outOfZone = false;
            //Debug.Log("InZone: "+gameObject);
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == coll.gameObject.name)
        {
            time = 0;
            outOfZone = true;
            //Debug.Log("outZone"+gameObject);
        }      
    }

    private void Update()
    {     
        if (outOfZone)
        {
            time++;
            if (gameObject.GetComponent<Health>().currentHealth > 0)
            {
                if (time == interval)
                {
                    //Debug.Log("Damage Dealt");
                    gameObject.GetComponent<Health>().TakeDamage(damage);
                    time = 0;
                }
            }
           
        }
    }
   

}
