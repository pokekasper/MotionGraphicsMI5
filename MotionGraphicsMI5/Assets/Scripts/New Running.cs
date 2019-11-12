using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRunning : MonoBehaviour
{/*
    //Variablen
    public float movementSpeed = 4;
    RigidBody rigidBody;
    Vector3 lookPos;
    //Methoden
    void Start()
    {
        rigidBody = GetComponent<RigidBody>();
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit, 100))
        {
            lookPos = hit.point;

        }
        Vector lookDir = lockPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.getAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rigidBody.AddForce(movement * movementSpeed / Time.deltaTime);
    }*/
}