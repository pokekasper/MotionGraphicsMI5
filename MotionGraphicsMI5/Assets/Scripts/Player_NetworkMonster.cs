using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Player_NetworkMonster : NetworkBehaviour {

    public GameObject firstPersonCharacter;
	public GameObject test;
	public AudioSource test2;


    public override void OnStartLocalPlayer()
    {
        GetComponent<Player>().enabled = true;
		GetComponent<TestAnimation>().enabled = true;
		GetComponent<Health>().enabled = true;
        GetComponent<DamageCircle>().enabled = true;
		test2.enabled = true;
		test.SetActive(true);
		//camera.GetComponent<Camera>().enabled = true;
		GetComponent<NetworkAnimator>().SetParameterAutoSend(0,true);
		GameObject.Find("Main Camera").SetActive(false);
        firstPersonCharacter.SetActive(true);
		
    }
}
