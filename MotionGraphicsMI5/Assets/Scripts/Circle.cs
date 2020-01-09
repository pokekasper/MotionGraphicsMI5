using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public Collider trigger;
    private float deltaTime = 0;
    private float time = 400;
    private bool outside = false;
    private void OnTriggerExit(Collider other)
    {
        if(other == trigger)
        {
            Debug.Log(gameObject);
            Debug.Log("Selected Trigger");
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            outside = true;
        }
        
        
    }
    private void Update()
    {
        if (outside)
        {
            deltaTime++;
            if (deltaTime > time)
            {
                Destroy(gameObject);
            }
        }
    }
    

}
