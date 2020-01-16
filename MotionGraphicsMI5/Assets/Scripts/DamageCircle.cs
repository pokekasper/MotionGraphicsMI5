using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCircle : MonoBehaviour
{
    public SphereCollider coll;
    public bool outOfZone = false;
    public int interval = 100;
    public int damage = 2;
    public int time=0;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger in Zone:"+ other.gameObject);
        if (other.gameObject.name == coll.gameObject.name)
        {
            time = 0;
            outOfZone = false;
            Debug.Log("OutofZone");
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == coll.gameObject.name)
        {
            time = 0;
            outOfZone = true;
            Debug.Log("InZone");
        }
        
    }
    private void Update()
    {
        
        if (outOfZone)
        {
            time++;
            if (time == interval)
            {
                Debug.Log("Damage Dealt");
                gameObject.GetComponent<Health>().TakeDamage(damage);
                time = 0;
            }
        }
    }
    // Update is called once per frame

}
