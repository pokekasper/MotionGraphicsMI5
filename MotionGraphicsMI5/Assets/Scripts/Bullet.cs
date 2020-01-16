using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float speed;
	public float maxTime;
    public float timeCount;
    public Vector3 rotation = new Vector3(-5, 0, 0);

	private GameObject triggeringEnemy;
    public int damage;
    Vector3 mousePosition;
    Vector3 direction;
    Vector3 hitpoint;
    public GameObject parent;
	float hitDist = 0.0f;
    public GameObject player;
	Vector3 neuerVector;
	private int n;
	public float rotationSpeed;

	void Start()
    {
        timeCount = 0;
       /* 
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		neuerVector = new Vector3(x,0,z).normalized;
		Debug.Log("neuer Vector"+ neuerVector);
		*/
        
        
        //Debug.Log(direction.z);
        //transform.rotation = new Quaternion(0, direction.y, 0, 0);
       // Debug.Log(player.transform.rotation);
    }
    void Update()
    {
		 transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        //player = gameObject.GetComponent<Player>();

		//Vector3 direction = player.transform.forward;
		//player.transform.rotation.y

		//Debug.Log(direction);
		//direction.


		//gameObject.GetComponent<Rigidbody>().velocity = transform.forward * 6;
		//gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,direction.y,0) * speed, ForceMode.Impulse);
        //transform.position += transform.forward *speed* Time.deltaTime;

        //Debug.Log(mousePosition);
       
       
       //stransform.Rotate(rotation);
      
		//gameObject.GetComponent<Rigidbody>().AddForce(neuerVector * speed, ForceMode.Impulse);
		 //transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);

		//transform.Rotate(0,x,0);
		//transform.Translate(0,0,z);
        //Vorwärtsbewegung der "Kugel"
        
        timeCount += 1* Time.deltaTime;
		
		if(timeCount >= maxTime)
		{
            DestroyObject(this.gameObject);
			
		}
    }


	private void OnCollisionEnter(Collision collision)
	{
		var hit = collision.gameObject;
		var health = hit.GetComponent<Health>();
		if(health != null)
		{
			health.TakeDamage(damage);
		}

		Destroy(gameObject);
	}


	public void DestroyObject(GameObject obj)
    {

      //  GameObject waffenhalter = 
       // Debug.Log(waffenhalter);
       //axe.SetActive(true);
        Destroy(obj);
    }
}
