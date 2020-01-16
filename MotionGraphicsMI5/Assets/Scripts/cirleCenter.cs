using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cirleCenter : MonoBehaviour
{
    public SphereCollider coll;
    public float speed;
    public float endRadius;
	public GameObject test;
    GameObject[] array;
    
    void Update()
    {
		array= GameObject.FindGameObjectsWithTag("PlayerHolder");
		if(array.Length == 2)
		{
			if (coll.radius > endRadius)
			{
				test.gameObject.GetComponent<Health>().TakeDamage(5);
				coll.radius -= speed;
			}
		}
		
        
       
       
        //coll.size = new Vector3(coll.size.x - speed, coll.size.y, coll.size.z - speed);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(0, gameObject.transform.position.y, 0), coll.radius);
        
    }
}
