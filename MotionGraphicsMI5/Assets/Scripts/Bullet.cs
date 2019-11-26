﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float speed;
	public float maxTime;
    public float timeCount;

	private GameObject triggeringEnemy;
    public float damage;
    Vector3 mousePosition;
    Vector3 direction;
    Vector3 hitpoint;
	float hitDist = 0.0f;


	void Start()
    {
        timeCount = 0;
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


			}*/
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
        }
        mousePosition.y = transform.position.y;
        direction = (mousePosition - transform.position).normalized;
        Debug.Log(direction.z);
    }
    void Update()
    {
		
        transform.position += direction * Time.deltaTime;

       

        //Vorwärtsbewegung der "Kugel"
        

        //transform.Translate(Vector3.forward * Time.deltaTime *  speed);
        timeCount += 1* Time.deltaTime;
		
		if(timeCount >= maxTime)
		{
			Destroy(this.gameObject);
		}
    }

	public void OnTriggerEnter(Collider other)
	{
        //Debug.Log(other.gameObject.name);

		if(other.tag == "Enemy")
		{
			triggeringEnemy = other.gameObject;
			triggeringEnemy.GetComponent<Enemy>().health -= damage;
           // Debug.Log("damage dealt, hp remain: " + triggeringEnemy.GetComponent<Enemy>().health);
			Destroy(this.gameObject);
		}
	}
}
