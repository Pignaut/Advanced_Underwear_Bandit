using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Look : MonoBehaviour {

	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;


	Vector2 mouseLook;
	Vector2 smoothV;

	GameObject character;

	void Start () {
		character = this.transform.parent.gameObject;
	}

	void Update () {
		
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));

		smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1f / smoothing);
		mouseLook += smoothV;

		mouseLook.y = Mathf.Clamp (mouseLook.y, -90.0f, 90.0f);
		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		//character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);	//CAUSES CHARACTER TO SPIN
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, Vector3.up);

		
	}
}



































/*using System;
using UnityEngine;

public class Look : MonoBehaviour
{
	public float mouseSensitivity = 100.0f;
	public float clampAngle = 80.0f;

	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis

	void Start ()
	{
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
	}

	void Update ()
	{
		float mouseX = Input.GetAxis("Mouse X");
		float mouseY = -Input.GetAxis("Mouse Y");

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
		transform.rotation = localRotation;

	}
}








using UnityEngine;
using System.Collections;

public class Look : MonoBehaviour {

	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;

	GameObject character;

	// Use this for initialization
	void Start () {

		character = this.transform.parent.gameObject;
	}

	// Update is called once per frame
	void Update () {

		// MD = Mouse Delta
		var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));

		smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1f / smoothing);
		mouseLook += smoothV;

		mouseLook.y = Mathf.Clamp (mouseLook.y, -90.0f, 90.0f);
		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);
	}
}
*/