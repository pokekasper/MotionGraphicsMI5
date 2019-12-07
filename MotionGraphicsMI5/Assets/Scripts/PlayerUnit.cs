using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// A Playerunit is a unit controlled by a player
// this could be a character in an fps, a zergling in a rts
// or a scout in a tbs

public class PlayerUnit : NetworkBehaviour
{
	public GameObject playerObj;
	public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //How do i verfiy that i am allowed to mess around with this objecT?
		if( hasAuthority == false)
		{
			return;
		}
		
		
		
		
		//Player Movement
        if (Input.GetKey(KeyCode.W))
        {
            //Rotation
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 100f * Time.deltaTime);
            //Bewegung
            transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Rotation
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.back);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 100f * Time.deltaTime);
            //Bewegung
            transform.position += Vector3.back * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Rotation
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.left);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 100f * Time.deltaTime);
            //Bewegung
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            Debug.Log("player.transform.rotation: "+playerObj.transform.rotation);
        }   
        if (Input.GetKey(KeyCode.D))
        {
            //Rotation
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.right);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 100f * Time.deltaTime);
            //Bewegung
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
		
    }
}
