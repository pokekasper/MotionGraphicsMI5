using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Player : NetworkBehaviour
{
    //Variablen
	public float movementSpeed;
    public GameObject camera;

	public GameObject playerObj;

	public GameObject bulletSpawnPoint;
	public float waitTime;
	public GameObject bullet;
    public int playerTypeId;

	private Transform bulletSpawn;
    
    private Vector3 prevPos = new Vector3();
    private bool dreh = true;

    public float points;
    public float x;
    public float y;
	public float xx;
    public float yy;
    public float spawnTime=0.4f;
    public GameObject axe;
    public GameObject waffenhalter;
    public int i = 0;
    GameObject bulletSpawn1;
    public float activeTime = 2.0f;
    int time=40;
    public bool alive= true;
	public AudioSource shootAudio;
	public GameObject disconnect;
    //Methoden
    void Update()
    {
        Debug.Log("alive:"+alive);
        if (alive)
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


            if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
            {
                xx = Input.GetAxisRaw("Horizontal");
                yy = Input.GetAxisRaw("Vertical");
            }




            //Shooting
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Axe:" + axe);
                if (axe != null)
                {
                    Debug.Log("Axe nicht null:" + axe);
                    if (i == 0)
                    {
                        dreh = false;
                        Invoke("EnableMovement", 1f);
                        Rotatet(ray, hitDist, playerPlane);
                        StartCoroutine(Waiting(0.3f));
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
                    StartCoroutine(Waiting(0.3f));
                    //Invoke("CmdShoot",spawnTime);


                    Rotatet(ray, hitDist, playerPlane);
                    Invoke("EnableMovement", 1f);
                }
                Debug.Log("werfen i:" + i);



            }
            if (!Input.GetButtonDown("Fire") && dreh)
            {
                x = Input.GetAxisRaw("Horizontal");
                y = Input.GetAxisRaw("Vertical");


                if (x != 0 || y != 0)
                {
                    Vector3 direction = new Vector3(x, 0, y).normalized;
                    Move(direction);
                }


            }
            IEnumerator Waiting(float time)
            {
                Debug.Log("Mill:" + Time.deltaTime);
                yield return new WaitForSeconds(time);
                Debug.Log("Mill:" + Time.deltaTime);
                CmdFire();

            }


            if (!isLocalPlayer)
            {
                return;
            }
            time++;
            float xs = Input.GetAxis("Horizontal");
            float zs = Input.GetAxis("Vertical");
            if (playerTypeId == 0)
            {
                if (time > 57)
                {
                    dreh = true;
                }
                if (time > 75)
                {
                    if (Input.GetButtonDown("Fire"))
                    {
                        time = 0;
                        dreh = false;
                        StartCoroutine(Waiting(0.4f));
						shootAudio.Play();
                    }
                    // gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

                }
            }
            else if(playerTypeId == 1)
            {
                if (time > 60)
                {
                    dreh = true;
                }
                if (time > 45)
                {
                    if (Input.GetButtonDown("Fire"))
                    {
                        time = 0;
                        dreh = false;
                        StartCoroutine(Waiting(0.4f));
						shootAudio.Play();
                    }
                    // gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

                }
            }
            else if (playerTypeId == 2)
            {
                if (time > 110)
                {
                    dreh = true;
                }
                if (time > 110)
                {
                    if (Input.GetButtonDown("Fire"))
                    {
                        time = 0;
                        dreh = false;
                        StartCoroutine(Waiting(0.6f));
						shootAudio.Play();
                    }
                    // gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

                }
            }
            else if (playerTypeId == 3)
            {
                if (time > 31)
                {
                    dreh = true;
                }
                if (time > 21)
                {
                    if (Input.GetButtonDown("Fire"))
                    {
                        time = 0;
                        dreh = false;
                        StartCoroutine(Waiting(0.1f));
						shootAudio.Play();
                    }
                    // gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

                }
            }


			


            //transform.Rotate(0,xs,0);
            //transform.Translate(0,0,zs);


        }
        
		
        
        
    }

	public void BacktoMenu()
	{
		SceneManager.LoadScene("Menu");
	}


    [Command]
	void CmdFire()
	{
		Vector3 vector4 = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y+1,playerObj.transform.position.z);
		GameObject bullet1 = (GameObject)Instantiate(bullet, waffenhalter.transform.position, playerObj.transform.rotation);

		bullet1.GetComponent<Rigidbody>().velocity = bullet1.transform.forward * 10;
		if (playerTypeId==0)
        {
            bullet1.transform.Rotate(0, 180, 0);
        }
        else if(playerTypeId == 1)
        {
            bullet1.transform.Rotate(0, 0, 90);
        }
        else if (playerTypeId == 3)
        {
            bullet1.transform.Rotate(90, 90, 90);
        }
        NetworkServer.Spawn(bullet1);

		Destroy(bullet1, 2);
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
        /*if (axe != null)
        {
            bulletSpawn1.transform.Rotate(0, 120, 0);
        }
        else
        {
            bulletSpawn1.transform.Rotate(0, 270, 0);
        }*/
		
        

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
