using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableCursor : MonoBehaviour {

	// Update is called once per frame
	void Start ()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
}
