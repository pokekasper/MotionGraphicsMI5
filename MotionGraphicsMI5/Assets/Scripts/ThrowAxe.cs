using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAxe : MonoBehaviour
{
    public float throwPower = 1;
    public Rigidbody axeRb;
    public Vector3 mousePosition;
    public Vector3 direction;
    public float delay;
    private Quaternion rot;
    float hitDist = 0.0f;
    private Vector3 prevPos = new Vector3();
    private bool throwed = false;
    public GameObject parentNode;
    Vector3 startPosition;
    Quaternion startRotation;
    Vector3 startScale;
    public int i=0;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        
        
        axeRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
       
       // Debug.Log(direction.z);


        if (Input.GetMouseButtonDown(0))
        {
            if (i ==0 ) {
                
                throwed = true;
                Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    mousePosition = hit.point;
                }
                mousePosition.y = transform.position.y;
                direction = (mousePosition - transform.position).normalized;
                Invoke("AxeThrow", delay);
                i++;
                player2.GetComponent<Player2>().dreh = false;
                Invoke("EnableMovement", 1f);
            }
            else if(i==1)
            {

                throwed = false;
                GetComponent<WeaponScript>().activated = false;
                axeRb.velocity = Vector3.zero;
                axeRb.angularVelocity = Vector3.zero;
                
                
                i++;
            }
            else
            {
                Debug.Log("startPosition: " + startPosition);
                axeRb.transform.parent = parentNode.transform;
                transform.localScale = startScale;
                transform.localRotation = startRotation;
                transform.localPosition = startPosition;
                
                i = 0;
            }
            
        }
    }
    void EnableMovement()
    {
        player2.GetComponent<Player2>().dreh = true;
    }

    // Update is called once per frame
    public void AxeThrow()
    {
        startRotation = transform.localRotation;
        startPosition = transform.localPosition;
        startScale = transform.localScale;
        Debug.Log("startPosition: " + startPosition);
        prevPos = transform.position;
        axeRb.isKinematic = false;
        axeRb.transform.parent = null;

        /*
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
        }
        mousePosition.y = transform.position.y;
        direction = (mousePosition - transform.position).normalized;
        Debug.Log("transform.rotation.x: " + transform.rotation.x);
        Debug.Log("transform.rotation.y: " + transform.rotation.y);
        Debug.Log(transform.gameObject);
        rot = new Quaternion(transform.rotation.x,transform.rotation.y,0,0);
        rot.x = 0;
        rot.z = 0;
        //rot.y += 180;
         transform.rotation = rot;*/
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        if (playerPlane.Raycast(ray, out hitDist))
         {
             prevPos = transform.position;
             Vector3 targetPoint = ray.GetPoint(hitDist);
             //rot = Quaternion.LookRotation(targetPoint - transform.position);
            // rot.x = 0;
            // rot.z = 0;

            Vector3 rot = transform.rotation.eulerAngles;
            rot = new Vector3(0, rot.y + 180, 0);
            transform.rotation = Quaternion.Euler(rot);

           
         }

        axeRb.AddForce(direction.normalized * throwPower, ForceMode.Impulse);

        
        
        GetComponent<WeaponScript>().activated = true;

    }
}
