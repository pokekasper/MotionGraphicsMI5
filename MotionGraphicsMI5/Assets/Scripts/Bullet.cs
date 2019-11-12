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
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, (transform.position - UnityEngine.Camera.main.transform.position).magnitude));
            mousePosition.y = 0;
            mousePosition.x = 9.68f;
            mousePosition.Normalize();
            Debug.Log(mousePosition);
            
        }
     
       
        //Vorwärtsbewegung der "Kugel"
        transform.Translate(mousePosition * (-1) * Time.deltaTime * speed);
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
