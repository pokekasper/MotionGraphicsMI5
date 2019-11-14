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
            Debug.Log(mousePosition);
            shoot();
            
        }


        //Vorwärtsbewegung der "Kugel"
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;
        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
        }

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
