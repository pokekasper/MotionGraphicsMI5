﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    public Animator anim;
    private bool dead;
    bool alive;
    
    int i;
    public Player axe;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //dead = Get
        alive = gameObject.GetComponent<Player>().alive;
        
    }

    // Update is called once per frame
    void Update()
    {
      //  if (!dead)
       // {
        if (axe != null)
        {
            i = axe.i;
        }

        //Debug.Log("i:" + i);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);

        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if(Input.GetButtonDown("Fire")&& axe==null)
            {
        anim.SetBool("isShooting", true);
            }
        else if (Input.GetButtonDown("Fire") && i== 1)
        {
            anim.SetBool("isShooting", true);
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
        if (!alive)
        {
            anim.SetBool("isDead", true);
        }
      //  }
        
        
    }
}
