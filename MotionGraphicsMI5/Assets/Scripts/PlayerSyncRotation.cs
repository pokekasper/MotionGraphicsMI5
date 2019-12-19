using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSyncRotation : NetworkBehaviour
{

	[SyncVar]private Quaternion syncPlayerRotation;
	[SyncVar]private Quaternion syncCamRotation;

	[SerializeField]private Transform playerTransform;
	[SerializeField]private Transform camTransform;
	[SerializeField]private float lerpRate = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TransmitRotation();
		LerpRotations();
    }

	void LerpRotations()
	{
		if(!isLocalPlayer)
		{
			playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, syncPlayerRotation, Time.deltaTime * lerpRate);
			camTransform.rotation = Quaternion.Lerp(camTransform.rotation, syncCamRotation, Time.deltaTime * lerpRate);
		}
	}

	[Command]
	void CmdProvideRotationstoServer(Quaternion playerRot, Quaternion camRot)
	{
		syncPlayerRotation = playerRot;
		syncCamRotation = camRot;
	}

	[Client]
	void TransmitRotation()
	{
		if (isLocalPlayer)
		{
			CmdProvideRotationstoServer(playerTransform.rotation, camTransform.rotation);
		}
	}
}
