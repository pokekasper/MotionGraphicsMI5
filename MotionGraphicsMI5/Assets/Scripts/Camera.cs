using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //Variablen
	public Transform player;
	public float smooth = 0.3f;

	public float height;

	private Vector3 velocity = Vector3.zero;

	//Methoden
	void Update()
	{
		Vector3 pos = new Vector3();
		pos.x = player.position.x;
		pos.y = player.position.y + height;
		//7 steht dafür wie weit die Kamera hinter dem Spieler ist
		pos.z = player.position.z - 7f;

		//erster Wert: Anfangsposition, zweiter Wert: aktuelle/Endpostion, dritter Wert: Geschwindkeit, vierter Wert: Smoothness
		transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
	}


}
