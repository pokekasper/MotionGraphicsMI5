using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{
    public Animator anim;
    int i=0;
    public ThrowAxe throwAxe;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        i = throwAxe.i;
        Debug.Log("i:" + i);
        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)|| Input.GetKey("space"))
        {
            anim.SetBool("isWalking", true);

        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (Input.GetMouseButtonDown(0) && i==1)
        {
            anim.SetBool("isShooting", true);
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
    }
}
