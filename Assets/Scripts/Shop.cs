using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

	public Canvas canvas;
	public GameObject txt;

	void start()
	{
		//GameObject.FindGameObjectWithTag("Canvas").

		canvas = GetComponent<Canvas> ();
		txt = canvas.GetComponentInChildren<GameObject> ();


	}
}
