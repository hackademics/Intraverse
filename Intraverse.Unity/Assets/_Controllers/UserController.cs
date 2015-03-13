//http://wiki.unity3d.com/index.php?title=RigidbodyFPSWalker

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]

public class UserController : MonoBehaviour {

	
	public float WalkSpeed = 10.0f;
	public float RunBoost = 20.0f;
	public float ReverseSpeed = 10.0f;
	public float StrafeSpeed = 5.0f;
	public float BoostForce = 40.0f;
	public float BoostCeiling = 50.0f;
	public float JumpHeight = 20.0f;
	public float MouseSensitivity = 8.0f;
	public float Gravity = 5.0f;
	public float LookUpMax = 20.0f;
	public float LookDownMax = -20.0f;
	public bool EnableRunning = true;
	public bool EnableJumping = true;
	public bool EnableBoosting = true;

	private Rigidbody rb;
	private float mouseX = 0.0f;
	private float mouseY = 0.0f;
	private bool isSpawned = false;


	protected void Start(){

		rb = GetComponent<Rigidbody> ();
		rb.freezeRotation = true;
		Spawn ();

	}

	private void Update(){
		Cursor.visible = false;


		if(IsMouseLook())
			MouseLook();
	}


	protected void FixedUpdate () {



		if (!isSpawned) {
			return;
		}

		if (transform.position.y < 0) {
			isSpawned = false;
			Spawn();
			return;
		}

		if (IsMoving ())
			Move();

		if(IsJumping())
			Jump();

		if(IsBoosting())
			Boost();




		if(Input.GetKey(KeyCode.F)){
			Debug.Log("fart");
		}
		//apply custom gravity
		rb.AddForce (new Vector3 (0, (-Gravity * rb.mass), 0));

	}

	public void Spawn(){
		this.transform.position = new Vector3 (0, 5, 0);
		isSpawned = true;

	}

	private void Move(){

		var runMulti = 0.0f;

		if (IsRunning () && EnableRunning) {
			runMulti = RunBoost;
		}

		if (Input.GetAxis ("Vertical") > 0) {
			rb.AddForce(transform.forward * (WalkSpeed + runMulti));
		}
		
		if (Input.GetAxis ("Vertical") < 0) {
			rb.AddForce(-(transform.forward * (ReverseSpeed + runMulti)));
		}
		
		if (Input.GetAxis ("Horizontal") > 0) {
			rb.AddForce(transform.right * StrafeSpeed);
		}
		
		if (Input.GetAxis ("Horizontal") < 0) {
			rb.AddForce(-(transform.right * StrafeSpeed));
		}
	}

	private bool IsMoving(){

		return (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0);
	}

	private bool IsRunning(){	

		return (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift) || Input.GetKey(KeyCode.E));		
	}

	private void Jump(){

		if (!EnableJumping)
			return;

		rb.velocity = new Vector3(rb.velocity.x, JumpHeight, rb.velocity.z);		
	}

	private bool IsJumping(){	

		return (Input.GetButton ("Jump") && transform.position.y < 2.0f);	
	}

	private void Boost(){

		if (!EnableBoosting)
			return;

		rb.velocity = new Vector3(rb.velocity.x, GetBoostVelocity(), rb.velocity.z);		
	}

	private bool IsBoosting(){

		return (Input.GetMouseButton (1) && transform.position.y < BoostCeiling);
	}

	private float GetBoostVelocity(){

		return Mathf.Sqrt(2 * BoostForce * Gravity);
	}

	private void MouseLook(){
		
		mouseX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * MouseSensitivity;
		mouseY += Input.GetAxis ("Mouse Y") * MouseSensitivity;
		mouseY = Mathf.Clamp (mouseY, LookDownMax, LookUpMax);
		
		transform.localEulerAngles = new Vector3(-mouseY, mouseX, 0);
	}

	private bool IsMouseLook(){

		return (Input.GetAxis ("Mouse Y") != 0 || Input.GetAxis ("Mouse X") != 0);
	}

	private bool IsOutOfBounds(){

		return transform.position.y <= -1.0f;
	}


	void OnCollisionEnter(Collision c) {

		if (c.collider.gameObject.name == "turret") {
			isSpawned = false;
			Spawn ();

		}
	}




}
