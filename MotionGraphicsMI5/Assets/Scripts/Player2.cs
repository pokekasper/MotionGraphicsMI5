using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //Variablen
    public float movementSpeed;
    public GameObject camera;

    public GameObject playerObj;


    public float waitTime;

    private Vector3 prevPos = new Vector3();
    public bool dreh = true;

    public float points;
    private float x;
    private float y;
    //Methoden
    void Update()
    {

        Plane playerPlane = new Plane(Vector3.up, transform.position);

        //Postion der Maus
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitDist = 0.0f;
        prevPos = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            Rotatet(ray, hitDist, playerPlane);
        }


            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");


            if ((x != 0 || y != 0) && dreh)
            {
                Vector3 direction = new Vector3(x, 0, y).normalized;
                Move(direction);
            }



    }
    void Rotatet(Ray ray, float hitDist, Plane playerPlane)
    {
        if (playerPlane.Raycast(ray, out hitDist) && Input.GetMouseButtonDown(0))
        {
            prevPos = transform.position;
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 150f * Time.deltaTime);
        }
    }
	
            void Move(Vector3 vector)
            {
                Quaternion targetRotation = Quaternion.LookRotation(vector);
                targetRotation.x = 0;
                targetRotation.z = 0;
                playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 10f * Time.deltaTime);
                //Bewegung
                transform.position += vector * movementSpeed * Time.deltaTime;
            }
}
