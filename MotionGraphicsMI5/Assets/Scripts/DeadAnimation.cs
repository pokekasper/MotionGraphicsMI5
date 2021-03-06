﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadAnimation : MonoBehaviour
{
    public Animator anim;
    private bool dead;
    bool alive;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        alive = gameObject.GetComponent<Player>().alive; 
    }

    void Update()
    {
        if (!alive)
        {
            anim.SetBool("isDead", true);
        }        
    }
}
