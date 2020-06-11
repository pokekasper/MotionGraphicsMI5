using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cirleCenter : MonoBehaviour
{
    public SphereCollider coll;
    public float speed;
    public bool startMinRadius = false;
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
		else if (startMinRadius)
        {
            coll.radius -= speed;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(0, gameObject.transform.position.y, 0), coll.radius);       
    }
}
