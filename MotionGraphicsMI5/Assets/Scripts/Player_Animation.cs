﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_Animation : NetworkBehaviour {

    public Animator playerAnimator;
	
	void Update ()
    {
        CheckForPlayerInput();
	}

    void CheckForPlayerInput()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (!gameObject.GetComponent<Player>().alive)
        {
			Debug.Log("TEST");
            playerAnimator.SetBool("isDead", true);
        }

        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0 ||
            Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }

    }

}

