using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveColl : MonoBehaviour
{
    public Collider coll;
    public float time = 0.3f;
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ActivedColl", time);
    }
    void ActivedColl()
    {
        coll.enabled = true;
    }
    // Update is called once per frame
    
}
