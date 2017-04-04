using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {

	public float speed = 10.0f;
	private GameObject ship;

	// Use this for initialization
	void Start () {

		ship = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("w")) {
			transform.Rotate (-50, 0, 0);
			transform.Translate ((Vector3.forward * Time.deltaTime) * speed);
			transform.Rotate (+50, 0, 0);
		}
		
		if (Input.GetKey ("s")) {
			transform.Rotate (-50, 0, 0);
			transform.Translate ((Vector3.back * Time.deltaTime) * speed);
			transform.Rotate (+50, 0, 0);
		}
		
		if(Input.GetKey("a"))
			transform.Translate ((Vector3.left * Time.deltaTime) * speed);
		
		if(Input.GetKey("d"))
			transform.Translate ((Vector3.right * Time.deltaTime) * speed);


		if (Input.GetKey ("c"))
			transform.position = Vector3.MoveTowards (transform.position, ship.transform.position, (speed * 4));

	}
}
