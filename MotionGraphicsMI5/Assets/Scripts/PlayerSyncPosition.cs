﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSyncPosition : NetworkBehaviour
{

	[SyncVar]
	private Vector3 syncPos;
	
	[SerializeField] Transform myTransform;
	[SerializeField] float lerpRate = 15;

    // Update is called once per frame
    void FixedUpdate()
    {
        TransmitPosition();
		LerpPosition();
    }

	void LerpPosition()
	{
		if (!isLocalPlayer)
		{
			myTransform.position = Vector3.Lerp(myTransform.position, syncPos, Time.deltaTime * lerpRate);
		}
	}

	[Command]
	void CmdProvidePositiontoServer(Vector3 pos)
	{
		syncPos = pos;
	}

	[ClientCallback]
	void TransmitPosition()
	{
		CmdProvidePositiontoServer(myTransform.position);
	}

}
