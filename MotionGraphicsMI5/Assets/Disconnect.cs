using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disconnect : MonoBehaviour
{
	public GameObject disconnect;

	private void Awake()
	{
		disconnect.SetActive(false);
	}

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
			{
				disconnect.SetActive(true);
			}
			else if(Input.GetKeyUp(KeyCode.Escape))
			{
				disconnect.SetActive(false);
			}
    }
}
