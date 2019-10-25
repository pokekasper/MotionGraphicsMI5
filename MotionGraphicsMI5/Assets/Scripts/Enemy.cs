using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variablen
	public float health;
	public float pointsToGive;

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
		Destroy(this.gameObject);

		player.GetComponent<Player>().points += pointsToGive;
	}
}
