using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class MoveVehicle : MonoBehaviour {

	public NavMeshAgent agent;
	private RaycastHit hit;
	private Vector3 Destination;
	private Vector3 startLoc;

	private bool showGUI;
	bool showing;

	public Canvas canv;
	private MoveVehicle mov;
	private canMouseLook myCam;



	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();

		canv = GetComponent<Canvas> ();
	}
	
	// Update is called once per frame
	void Update () {

		//if (Input.GetButton ("Fire1"))
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit))
			{
				Destination.x = hit.point.x;
				Destination.y = transform.position.y;
				Destination.z = hit.point.z;

				agent.transform.LookAt (Destination);

				agent.SetDestination (Destination);
			}
		}
	}

	public void setShowGUI(bool show)
	{
		showGUI = show;
	}

	public void OnGUI()
	{
		if (showGUI)
		{
			if (GUI.Button (new Rect (transform.position.x + 20, transform.position.y + 20, 100, 20), "Enter Station"))
			{
				agent.SetDestination (transform.position);

				showing = true;

				canv.gameObject.SetActive (showing);

				mov.enabled = !mov.enabled;
				myCam.enabled = !myCam.enabled;
			}
		}
	}


}