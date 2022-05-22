using UnityEngine;

public class FreePlayerMovement : MonoBehaviour {
	
	// public Rigidbody rb;
	public GameObject player;
	public float jumpheight;
	public CharacterController controlmove;
	public float Gravity = -9.8f;
	public float Jumptimer = 0.2f;
	public float didIjump = 0f;
	public float AmIGRounded = 0f;
	public float GroundedTimer = 0.2f;
	public bool amImoving = false;
	public Vector3 crouch;
	public Vector3 normsize;
	public GameManager game;
	public Transform orientation;
	[Range(0, 0.05f)]
	public float SpeedMultiplier;
	private Camera fpsCamera;

	private Vector3 movement;
	public Vector3 momentum;

	 // private float horizmove;

	public Transform GroundCheck; // position of the sphere
	public SphereCollider GroundCheckRadius;
	public LayerMask groundMask; //  allows me to choose which gameobjects to detect contact
	bool isGrounded;
	bool CanIJump;


	public Animator animate; // link to animator used

	void Start()
	{
		controlmove = GetComponent<CharacterController> ();
		crouch.y = 0.3f;

	}

	void Update()
	{
		fpsCamera = transform.Find ("FpsCamera").GetComponent<Camera>();
		if(Input.GetKeyDown("r"))
		{
			game.Restart();
		}
	}
	void FixedUpdate () 
	{
			isGrounded = Physics.CheckSphere (GroundCheck.position, GroundCheckRadius.radius, groundMask); // creates a sphere to detect if i'm touching the ground
			// movement = new Vector3 (Input.GetAxis ("Horizontal") * move * Time.deltaTime, movement.y, Input.GetAxis ("Vertical") * move * Time.deltaTime);

			if (Input.GetButtonDown ("Jump")) {
				CanIJump = true;
			}

			float ystore = movement.y;
			movement = (orientation.transform.forward * Input.GetAxis ("Vertical") * SpeedMultiplier ) + (orientation.transform.right * Input.GetAxis ("Horizontal") * SpeedMultiplier); // movement
			movement = movement.normalized; // same speed when two buttons are pressed
			movement.y = ystore; // save y value to smoothen jumps
			movement += momentum;

			didIjump -= Time.deltaTime;
			AmIGRounded -= Time.deltaTime;
			if (controlmove.isGrounded) {
				if (haveIJumped()) {
					didIjump = Jumptimer;
					CanIJump = true;
				}
				if ((didIjump > 0)) {
					movement.y = Mathf.Sqrt (jumpheight * -2 * Gravity);
				}
			} else {
				if ((didIjump > 0) && (AmIGRounded > 0)) {
					CanIJump = true;
					didIjump = 0;
					AmIGRounded = 0;
					movement.y = Mathf.Sqrt (jumpheight * -2 * Gravity);
				}
			}
		
		
		controlmove.Move (movement);

			movement.y += Gravity * Time.deltaTime;

			controlmove.Move (movement);

			if (movement.x > 0) {
				amImoving = true;
			} else {
				amImoving = false;
			}
			//animate.SetBool ("CanJump", CanIJump);	
			//animate.SetBool ("isGrounded", controlmove.isGrounded); // determines when our animations act
			//animate.SetFloat ("Speed", (Mathf.Abs (Input.GetAxis ("Vertical"))) + (Mathf.Abs (Input.GetAxis ("Horizontal")))); // detects movement, so player moves as animated
			
	}
	 
	void resetGravity()
	{
		movement.y = 0f;
	}
	
	bool haveIJumped()
	{
		return Input.GetButtonDown ("Jump");
	}
	bool amIsliding()
	{
		return Input.GetKey(KeyCode.LeftShift);

	}


	
}
	
	
