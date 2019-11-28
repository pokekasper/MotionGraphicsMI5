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
    private bool dreh = true;

    public float points;
    private float x;
    private float y;
    public float spawnTime=0.4f;
    public GameObject axe;
    public GameObject waffenhalter;

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

            Rotatet(ray, hitDist, playerPlane);
        }


        
        

        

		//Shooting
		if (Input.GetMouseButtonDown(0))
		{
            dreh = true;
            Invoke("Shoot",spawnTime);
            Rotatet(ray, hitDist, playerPlane);
            Invoke("EnableMovement", 3f);

        
			
		}
        if(!Input.GetMouseButtonDown(0) && !dreh)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");


            if (x != 0 || y != 0)
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

        }
	}

	void Shoot()
	{

      //  Waiting(2f);
		bulletSpawn = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawn.rotation = bulletSpawnPoint.transform.rotation;
        bulletSpawn.Rotate(0, 180, 0);
        axe.SetActive(false);


    }
    void EnableMovement()
    {
        dreh = false;
    }
    void Rotatet(Ray ray, float hitDist, Plane playerPlane)
    {
        if (playerPlane.Raycast(ray, out hitDist) && Input.GetMouseButtonDown(0))
        {
            Debug.Log("geht");
            prevPos = transform.position;
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 150f * Time.deltaTime);
            // Debug.Log("player.transform.rotation: " + playerObj.transform.rotation);
        }
    }
 

}
