using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	
	public CharacterController pacman;
	public Animator animate;
	[Range(1,50)]
	public float speed;
	public float x,y; //I'll use these for my axis for movement
	public Transform groundcheck, orientation;
	public LayerMask groundMask;
	[SerializeField]
	bool isGrounded;
	public Vector3 movement;
	[SerializeField]
	Vector3 gravity;
	
	void Start()
	{
		animate = GetComponentInChildren<Animator>();
		/*
		animate.SetBool("Idle", true);
		animate.SetBool("Moving", false);
		*/
	}
	
	void MyInput () {
		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");
	}
	
	// Update is called once per frame
	void Update () {
		MyInput();
		gravity = Physics.gravity;
		RaycastHit ray;
		isGrounded = Physics.Raycast(groundcheck.position, groundcheck.transform.TransformDirection(-Vector3.up),out ray, 1f, groundMask);	
		//isGrounded = Physics.CheckSphere(groundcheck.position, 1f, groundMask);
		/* For some reason, using CheckSphere is constantly ticked*/
		movement = (x * orientation.right) + (y * orientation.forward);
		movement = movement.normalized;
		movement += (gravity / 5f).normalized;
		//animate.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"))));
		//animate.SetBool("CanJump", pacman.isGrounded);
		pacman.Move(movement);
	}
	
}
