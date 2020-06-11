using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variablen
	public float health;
	public float pointsToGive=0;
    public bool dead;

	public GameObject player;


	//Methoden
	public void Start()
	{
		player = GameObject.FindWithTag("Player");
	}

	public void Update()
	{
		if(health <= 0)
		{
			Die();
		}
	}

	public void Die()
	{
		print(this.gameObject.name + " has died!");
        dead = true;	
	}
}
