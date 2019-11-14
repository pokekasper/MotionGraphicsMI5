﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)|| Input.GetKey("space"))
        {
            anim.SetBool("isWalking", true);

        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isShooting", true);
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
    }
}
