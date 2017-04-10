using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveVehicle : MonoBehaviour {


	public NavMeshAgent agent;
	private RaycastHit hit;
	private Vector3 Destination;
	private Vector3 startLoc;

	static public float pX;
	static public float pY;
	static public float pZ;

	private bool showGUI;

	private MoveVehicle mov;
	public canMouseLook myCam;


	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		mov = GameObject.FindGameObjectWithTag ("Player").GetComponent<MoveVehicle> ();
		myCam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<canMouseLook> ();

		Debug.Log ("showGUI: " + showGUI);

		this.transform.position = new Vector3 (pX, pY, pZ);
		myCam.transform.position = new Vector3 (pX, myCam.transform.position.y, (pZ - 2));
	}
	
	// Update is called once per frame
	void Update () {
		
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

				savePosition ();
				loadPosition ();

				SceneManager.LoadScene ("stationMenu", UnityEngine.SceneManagement.LoadSceneMode.Single);

				mov.enabled = !mov.enabled;
				myCam.enabled = !myCam.enabled;
			}
		}
	}

	void savePosition()
	{
		PlayerPrefs.SetFloat ("p_X", transform.position.x);
		PlayerPrefs.SetFloat ("p_Y", transform.position.y);
		PlayerPrefs.SetFloat ("p_Z", transform.position.z);
	}

	void loadPosition()
	{
		pX = PlayerPrefs.GetFloat ("p_X");
		pY = PlayerPrefs.GetFloat ("p_Y");
		pZ = PlayerPrefs.GetFloat ("p_Z");
	}

}
