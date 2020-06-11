using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public bool activated;
    public float rotationSpeed;
    Vector3 axis;
    Vector3 neuAxis;
    public int damage;
    public bool done = false;


    void Update()
    {
        if (activated)
        {
            transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        
        if (other.tag == "Enemy")
        {
            GameObject triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<Enemy>().health -= damage;
            Debug.Log("damage dealt, hp remain: " + triggeringEnemy.GetComponent<Enemy>().health);
         
        }

    }
}