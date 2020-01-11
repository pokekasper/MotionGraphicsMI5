using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
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
    public int i = 0;
    GameObject bulletSpawn1;
    public float activeTime = 2.0f;
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
            Debug.Log("Axe:" + axe);
            if(axe != null)
            {
                Debug.Log("Axe nicht null:" + axe);
                if (i == 0)
                {
                    dreh = false;
                    Invoke("EnableMovement", 1f);
                    Rotatet(ray, hitDist, playerPlane);
                    StartCoroutine(Waiting());
                    /*   axe.SetActive(false);
                       i++;
                       Rotatet(ray, hitDist, playerPlane);
                       CmdShoot();
                       */
                    i++;
                }
                else if (i == 1)
                {
                    axe.SetActive(true);
                    Destroy(bulletSpawn1);
                    i = 0;
                }
            }
            else
            {
                dreh = false;
                //Invoke("CmdShoot",spawnTime);
                CmdShoot();

                Rotatet(ray, hitDist, playerPlane);
                Invoke("EnableMovement", 1f);
            }
            Debug.Log("werfen i:" + i);

        
			
		}
        if(!Input.GetMouseButtonDown(0) && dreh)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");


            if (x != 0 || y != 0)
            {
                Vector3 direction = new Vector3(x, 0, y).normalized;
                Move(direction);
            }


        }
        IEnumerator Waiting()
        {
            Debug.Log("Mill:" + Time.deltaTime);
            yield return new WaitForSeconds(0.1f);
            Debug.Log("Mill:" + Time.deltaTime);
            axe.SetActive(false);
           
            
            CmdShoot();
            
        }
    }
    

	[Command]
	void CmdShoot()
	{

        //  Waiting(2f);
        //bulletSpawn = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        //bulletSpawn.rotation = bulletSpawnPoint.transform.rotation;
        //bulletSpawn.Rotate(0, 180, 0);
        bulletSpawn1 = (GameObject)Instantiate(bullet, bulletSpawnPoint.transform.position, waffenhalter.transform.rotation);
        bulletSpawn1.transform.rotation = bulletSpawnPoint.transform.rotation;
        if (axe != null)
        {
            bulletSpawn1.transform.Rotate(0, 120, 0);
        }
        else
        {
            bulletSpawn1.transform.Rotate(0, 270, 0);
        }
		
        

		//bulletSpawn1.GetComponent<Rigidbody>().velocity = bulletSpawn1.transform.forward * 6;

		NetworkServer.Spawn(bulletSpawn1);
        Invoke("activeSet", activeTime);
        Destroy(bulletSpawn1, activeTime);
        
       


        //axe.SetActive(false);


    }
    void activeSet()
    {
        if(axe != null)
        {
            
            axe.SetActive(true);
        }
            
    }


    void EnableMovement()
    {
        dreh = true;
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
