using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	public float speed;
	public float maxDist;

	private GameObject triggeringEnemy;
    public float damage;
    Vector3 mousePosition = new Vector3();
    Vector3 hitpoint;

    void Start()
    {
        
    }
    void Update()
    {
        float hitDist = 0.0f;
     
        Vector3 lookat = UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (transform.position - UnityEngine.Camera.main.transform.position).magnitude));
        lookat.y = transform.position.y;
        //Vorwärtsbewegung der "Kugel"
        transform.LookAt(lookat);
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
