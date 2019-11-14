using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float speed;
	public float maxDist;

	private GameObject triggeringEnemy;
    public float damage;
    Vector3 mousePosition;
    Vector3 hitpoint;
	float hitDist = 0.0f;


	void Start()
    {
		/*
			Plane playerPlane = new Plane(Vector3.up, transform.position);
			Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
			if (playerPlane.Raycast(ray, out hitDist))
			{
				Vector3 targetPoint = ray.GetPoint(hitDist);
				Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				targetRotation.x = 0;
				targetRotation.z = 0;
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);


			}
			*/
		Debug.Log("ngfh"+Input.mousePosition);
		mousePosition = Input.mousePosition;
		mousePosition.z = transform.position.z - UnityEngine.Camera.main.transform.position.z;
		mousePosition = UnityEngine.Camera.main.ScreenToWorldPoint(mousePosition);
		Debug.Log(mousePosition);
		mousePosition.y = transform.position.y;
	}
    void Update()
    {
		Debug.Log(mousePosition);
		transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed*Time.deltaTime);


        //Vorwärtsbewegung der "Kugel"
        

        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        maxDist += 1* Time.deltaTime;
		
		if(maxDist >= 5)
		{
			Destroy(this.gameObject);
		}
    }

	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Enemy")
		{
			triggeringEnemy = other.gameObject;
			triggeringEnemy.GetComponent<Enemy>().health -= damage;
			Destroy(this.gameObject);
		}
	}
}
