using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Player_Network : NetworkBehaviour {

    public GameObject firstPersonCharacter;
    public GameObject[] characterModel;

    public override void OnStartLocalPlayer()
    {
        GetComponent<Player2>().enabled = true;
		GetComponent<NetworkAnimator>().SetParameterAutoSend(0,true);
		GameObject.Find("Main Camera").SetActive(false);
        firstPersonCharacter.SetActive(true);

        foreach (GameObject go in characterModel)
        {
            go.SetActive(false);
        }
    }
}
