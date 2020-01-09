using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cirleCenter : MonoBehaviour
{
    public SphereCollider coll;
    public float speed;
    public float endRadius;
    
    
    void Update()
    {
        if (coll.radius > endRadius)
        {
            coll.radius -= speed;
        }
       
       
        //coll.size = new Vector3(coll.size.x - speed, coll.size.y, coll.size.z - speed);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(0, 10, 0), coll.radius);
        
    }
}
