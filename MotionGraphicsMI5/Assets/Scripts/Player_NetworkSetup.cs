using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player_NetworkSetup : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		
		if (isLocalPlayer)
		{
			//Debug.Log("Test");
			GameObject.Find("Main Camera").SetActive(false);

			GetComponent<Player2>().enabled = true;

			GetComponent<NetworkAnimator>().SetParameterAutoSend(0,true);
		
		}

    }

	public override void PreStartClient()
	{
		GetComponent<NetworkAnimator>().SetParameterAutoSend(0,true);
	}
}
