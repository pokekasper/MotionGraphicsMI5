using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public bool activated;
    public float rotationSpeed;
    Vector3 axis;
    Vector3 neuAxis;
    public bool done = false;


    void Update()
    {
        if (activated)
        {
            
            //axis.z = 0;
            /*if (!done)
            {
                axis = GetComponent<ThrowAxe>().direction;
                Vector3 neuAxis = new Vector3(axis.x, axis.y, 0);
                done = true;
            }*/
            
            transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        activated = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}