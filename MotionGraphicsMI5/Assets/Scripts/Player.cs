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
    private float x;
    private float y;

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
               // Debug.Log("player.transform.rotation: " + playerObj.transform.rotation);
            }
        }


        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        
        
        if(x!=0 || y!= 0)
        {
            Vector3 direction = new Vector3(x, 0, y).normalized;
            Move(direction);
        }
        

        void Move(Vector3 vector)
        {
            Quaternion targetRotation = Quaternion.LookRotation(vector);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 10f * Time.deltaTime);
            //Bewegung
            transform.position += vector * movementSpeed * Time.deltaTime;
        }

        /*

        //Player Movement
        if (Input.GetKey(KeyCode.W))
        {
            //Rotation
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 10f * Time.deltaTime);
            //Bewegung
            transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Rotation
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.back);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 10f * Time.deltaTime);
            //Bewegung
            transform.position += Vector3.back * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Rotation
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.left);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 10f * Time.deltaTime);
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
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 10f * Time.deltaTime);
            //Bewegung
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
        }
        */

		//Shooting
		if (Input.GetMouseButtonDown(0))
		{
            if(!(Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.S)) && !(Input.GetKey(KeyCode.W)) && !(Input.GetKey(KeyCode.D)))
            {
                Shoot();
            }
			
		}
	}

	void Shoot()
	{
		bulletSpawn = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
		bulletSpawn.rotation = bulletSpawnPoint.transform.rotation;
        bulletSpawn.Rotate(0, 180, 0);
        
	}

}
