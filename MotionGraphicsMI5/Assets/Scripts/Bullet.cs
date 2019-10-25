using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed;
	public float maxDist;

	private GameObject triggeringEnemy;
	public float damage;

    void Update()
    {
		//Vorwärtsbewegung der "Kugel"
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
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
