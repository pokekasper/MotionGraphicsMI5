using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed;
	public float maxTime;
    public float timeCount;
    public float rotationSpeed;
    public float hitDist = 0.0f;
    public GameObject player;
    public GameObject parent;
    public Vector3 rotation = new Vector3(-5, 0, 0);

	private GameObject triggeringEnemy;
    
    Vector3 mousePosition;
    Vector3 direction;
    Vector3 hitpoint;
	Vector3 neuerVector;
	private int n;
	

	void Start()
    {
        timeCount = 0;
    }
    void Update()
    {
		transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        
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
        Destroy(obj);
    }
}
