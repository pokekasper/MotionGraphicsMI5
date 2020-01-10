using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Player_Network : NetworkBehaviour {

    public GameObject firstPersonCharacter;
    public GameObject[] characterModel;
	public GameObject axe;
	//public GameObject camera;
	public GameObject test;


    public override void OnStartLocalPlayer()
    {
        GetComponent<Player2>().enabled = true;
		GetComponent<TestAnimation>().enabled = true;
		axe.GetComponent<ThrowAxe>().enabled = true;
		axe.GetComponent<WeaponScript>().enabled = true;
		//camera.GetComponent<Camera>().enabled = true;
		test.SetActive(true);
		GetComponent<NetworkAnimator>().SetParameterAutoSend(0,true);
		GameObject.Find("Main Camera").SetActive(false);
        firstPersonCharacter.SetActive(true);

        foreach (GameObject go in characterModel)
        {
            go.SetActive(false);
        }
    }
}
