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
    public float damage;
    Vector3 mousePosition;
    Vector3 direction;
    Vector3 hitpoint;
    public GameObject parent;
	float hitDist = 0.0f;
    public Player player;


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
        //transform.rotation = new Quaternion(0, direction.y, 0, 0);
    }
    void Update()
    {
        //player = gameObject.GetComponent<Player>();


        transform.position += direction *speed* Time.deltaTime;

        //Debug.Log(mousePosition);
        //transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
       
       transform.Rotate(rotation);
            

       

        //Vorwärtsbewegung der "Kugel"
        
        timeCount += 1* Time.deltaTime;
		
		if(timeCount >= maxTime)
		{
            DestroyObject(this.gameObject);
			
		}
    }

	public void OnTriggerEnter(Collider other)
	{
        
        Debug.Log(other.gameObject.name);

		if(other.tag == "Enemy")
		{

            triggeringEnemy = other.gameObject;
			triggeringEnemy.GetComponent<Enemy>().health -= damage;
            Debug.Log("damage dealt, hp remain: " + triggeringEnemy.GetComponent<Enemy>().health);
			Destroy(this.gameObject);
		}
        
	}
    public void DestroyObject(GameObject obj)
    {

      //  GameObject waffenhalter = 
       // Debug.Log(waffenhalter);
       //axe.SetActive(true);
        Destroy(obj);
    }
}
