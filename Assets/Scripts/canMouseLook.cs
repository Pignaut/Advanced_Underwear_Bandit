using UnityEngine;
using System.Collections;

public class canMouseLook : MonoBehaviour {

	public float dragSpeed = 2;
	private Vector3 dragOrigin;

	void Update()
	{
		if (Input.GetMouseButton (0)) {
			dragOrigin = Input.mousePosition;
			Debug.Log ("click");
			return;
		}

		if (!Input.GetMouseButton (0))
			return;

		Vector3 pos = Camera.main.ScreenToViewportPoint (Input.mousePosition - dragOrigin);
		Vector3 move = new Vector3 (pos.x * dragSpeed, 0, pos.y * dragSpeed);

		transform.Translate (move, Space.World);
	}
}
