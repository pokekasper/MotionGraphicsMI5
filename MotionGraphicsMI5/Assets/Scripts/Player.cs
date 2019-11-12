using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variablen
	public float movementSpeed;
    public GameObject camera;

	public GameObject playerObj;

	public GameObject bulletSpawnPoint;
	public float waitTime;
	public GameObject bullet;

	private Transform bulletSpawn;
    
    private Vector3 prevPos = new Vector3();

    public float points;

	//Methoden
	void Update()
	{
            
        //Spieler ist auf die MAus gerichtet
        //Aufspüren der Kameraposition
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        //Postion der Maus
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

		float hitDist = 0.0f;
        prevPos = transform.position;

        if (!Input.anyKey)
		{
            if (playerPlane.Raycast(ray, out hitDist))
            {
                prevPos = transform.position;
                Vector3 targetPoint = ray.GetPoint(hitDist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                targetRotation.x = 0;
                targetRotation.z = 0;
                playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 5f * Time.deltaTime);
            }
		}


        //Player Movement
        if (Input.GetKey(KeyCode.W))
			transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
		if(Input.GetKey(KeyCode.S))
			transform.position += Vector3.back * movementSpeed * Time.deltaTime;
		if(Input.GetKey(KeyCode.A))
            transform.position += Vector3.left* movementSpeed * Time.deltaTime;
		if(Input.GetKey(KeyCode.D))
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;


		//Shooting
		if (Input.GetMouseButtonDown(0))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		bulletSpawn = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
		bulletSpawn.rotation = bulletSpawnPoint.transform.rotation;
	}

}
