using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private float step;
	private float strafe;
	private float vSpeed = 0.0f;

	GameObject[] squad;

	//public static bool MOVETO;

	public float speed = 10.0f;
	public float jumpSpeed = 100.0f;
	public float gravity = 25.0f;

	// Use this for initialization
	void Start () {

		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update () {

		step = (Input.GetAxis ("Vertical") * speed) * Time.deltaTime;
		strafe = (Input.GetAxis ("Horizontal") * speed) * Time.deltaTime;
		transform.Translate (strafe, 0, step);
	
	}

	//	public bool getMOVETO()
	//	{
	//		return MOVETO;
	//	}
}