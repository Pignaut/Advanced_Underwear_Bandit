using UnityEngine;
using System.Collections;

// http://wiki.unity3d.com/index.php?title=FPSWalkerEnhanced - surplus features edited out

[RequireComponent (typeof(CharacterController))]
public class Move : MonoBehaviour {

	public float walkSpeed = 10.0f;
	// Normally, moving diagonally will multiply forwards and side movement moving you at 1.4x speed at diagonal
	public bool limitDiagonalSpeed = true;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	// Prevents standard character controllers from bouncing when moving on slopes
	public float antiBumpFactor = .75f;
	private Vector3 moveDirection = Vector3.zero; // Vector3.zero == Vector3(0, 0, 0)
	private bool grounded = false; // Check whether the player is on a floor
	public CharacterController controller;
	private Transform myTransform;
	private float speed;

	void Start () {
		controller = GetComponent<CharacterController> ();
		myTransform = transform;
		speed = walkSpeed;

	}

	void FixedUpdate () {

		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");
		float inputModifyFactor = (inputX != 0.0f && inputY != 0.0f && limitDiagonalSpeed) ? .7071f : 1.0f;

			
		moveDirection = new Vector3 (inputX * inputModifyFactor, -antiBumpFactor, inputY * inputModifyFactor);
		moveDirection = myTransform.TransformDirection (moveDirection) * speed;

		// Apply gravity movement
		moveDirection.y -= gravity * Time.deltaTime;

		// Apply the move and determine whether we are on the ground
		grounded = (controller.Move (moveDirection * Time.deltaTime) & CollisionFlags.Below) != 0;
	}
}




















/*using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	void Update()
	{
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
	}
}


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
		
		Cursor.lockState = CursorLockMode.Locked;   // keep confined to center of screen
	}

	// Update is called once per frame
	void Update () {

		step = (Input.GetAxis ("Vertical") * speed) * Time.deltaTime;
		strafe = (Input.GetAxis ("Horizontal") * speed) * Time.deltaTime;
		transform.Translate (strafe, 0, step);

	}
}*/