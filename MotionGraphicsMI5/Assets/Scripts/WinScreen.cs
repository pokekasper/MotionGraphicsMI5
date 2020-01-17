using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class WinScreen : NetworkBehaviour
{
	private GameObject[] gjs;
	private int anzahl = 0;
	private GameObject winner;
	public int anzahlSpieler = 4;
	public GameObject canvas;
	
	void Update()
    {
		

		anzahl = 0;
		gjs = GameObject.FindGameObjectsWithTag("PlayerHolder");
		if(gjs.Length == anzahlSpieler)
		{
			for(int i = 0; i < gjs.Length; i++)
			{
				if (gjs[i].GetComponent<Player>().alive)
				{
					anzahl++;
			
				}
			}
			if(anzahl == 1)
			{
				if (gameObject.GetComponent<Player>().alive)
				{
					if (isLocalPlayer)
					{
						canvas.SetActive(true);
				
					}
				}
			}
		}
    }
}
