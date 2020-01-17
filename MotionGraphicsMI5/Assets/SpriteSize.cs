using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSize : MonoBehaviour
{
    public SphereCollider coll;
    private float startRadius;
    private Vector3 startLocalScale;
    private float radius;
    private float verhältnisRadius;

    private void Start()
    {
        startRadius = coll.radius;
        startLocalScale = transform.localScale;
    }
    void Update()
    {
        radius = coll.radius;
        verhältnisRadius = radius / startRadius;

        transform.localScale = startLocalScale * verhältnisRadius; 
    }
}
