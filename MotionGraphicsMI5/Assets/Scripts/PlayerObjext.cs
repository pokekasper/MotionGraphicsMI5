using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObjext : NetworkBehaviour
{

	public GameObject PlayerUnitPrefab;
	GameObject myPlayerUnit;

    // Start is called before the first frame update
    void Start()
    {
		// is this my own local playerobject
		if(isLocalPlayer == false)
		{
			//this object belongs to another player
			return;
		}
		
		CmdSpawnMyUnit();

    }

    // Update is called once per frame
    void Update()
    {
        //Remember: update runs on everyons computer, wherether or not they own this
		//particular player object
		if( isLocalPlayer == false)
		{
			return;
		}
		
    }

	// Commands are special functions that only get executed on the server

	[Command]
	void CmdSpawnMyUnit()
	{
		//We are guaranteed to be on the server right now
		GameObject go = Instantiate(PlayerUnitPrefab);

		myPlayerUnit = go;

		//go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);

		//now that the object exists on the server, propagate it to all
		// the clients (and also wire up the NetworkIdentitty)
		NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
	}

	[Command]
	void CmdMoveUnitUp()
	{
		if(myPlayerUnit == null)
		{
			return;
		}

		myPlayerUnit.transform.Translate(0,1,0);
	}

}
