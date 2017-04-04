using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class stationScript : MonoBehaviour {

	private bool showGUI;
	private GameObject player;
	private MoveVehicle mov;

	//public Canvas canv;

	//bool showing;
	private canMouseLook myCam;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		mov = player.GetComponent<MoveVehicle> ();

		//showing = false;

		//canv = player.GetComponent<Canvas> ();

		myCam = player.GetComponent<canMouseLook> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (Vector3.up * (Time.deltaTime) * 2);
	}

	void OnTriggerEnter (Collider _collision)
	{
		Debug.Log ("Entered station area");
		showGUI = true;
		mov.setShowGUI (showGUI);
	}

	void OnTriggerExit (Collider _collision)
	{
		Debug.Log ("Exited station area");
		showGUI = false;
		mov.setShowGUI (showGUI);
	}
}
