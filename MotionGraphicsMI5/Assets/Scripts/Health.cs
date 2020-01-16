using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;
	[SyncVar (hook ="OnChangeHealth")]public int currentHealth = maxHealth;
	public RectTransform healthbar;

	public Animator anim;
    bool alive;

	public AudioSource dmgSound;
	public AudioSource deathSound;
    
    void Start()
    {
		OnChangeHealth(currentHealth);

        anim = GetComponent<Animator>();

        alive = gameObject.GetComponent<Player>().alive;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            anim.SetBool("isDead", true);
        }    
        
    }

	public void TakeDamage(int dmg)
	{
		if (!isServer)
		{
			return;
		}

		currentHealth -=dmg;
		dmgSound.Play();

		if(currentHealth <= 0)
		{
			currentHealth =0;
			RpcDeactivatePlayer();
		}
	}

	[ClientRpc]
    void RpcDeactivatePlayer()
    {
        GetComponent<Player>().enabled = false;
        GetComponent<TestAnimation>().enabled = false;
		//GetComponent<DeadAnimation>().enabled = true;
		gameObject.GetComponent<Player>().alive = false;
		deathSound.PlayDelayed(1f);
		//GetComponent<Player>().alive = false;
		

        if (isLocalPlayer)
        {
            //defeatText.SetActive(true);
        }
		

    }

	void OnChangeHealth(int health)
	{
		healthbar.sizeDelta = new Vector2(health, healthbar.sizeDelta.y);
	}
}
