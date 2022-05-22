using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	public float speed = 200f;
	public Rigidbody rb;
	public GameManager gam;
	public bool amIgrounded;
	public float jumpheight = 4f;
	public float jumpvelocity;
	public float Gravity = -9.8f;
	public Transform groundchecksphere;	
	public float jumptimer;
	public float jumptimefloat;
	public LayerMask GroundLayer;
	public SphereCollider ball;
	float x, y;
	public Transform orientation;
	
	void Start()
	{
		jumptimer = jumptimefloat;
	}
	
	private void MyInput() {
		x = Input.GetAxisRaw("Horizontal");
		y = Input.GetAxisRaw("Vertical");
	}
	
	
	bool isGrounded()
	{
		return Physics.CheckCapsule(ball.bounds.center, new Vector3(ball.bounds.center.x,
		 ball.bounds.min.y, ball.bounds.center.z), ball.radius * .9f,GroundLayer);
	}
	
	
	void Update ()
	{
		//amIgrounded = Physics.CheckSphere (groundchecksphere.position, 0.1f, ~(1 << 8));
		MyInput();		
		rb.AddForce(0,Gravity,0);
				
		rb.AddForce(orientation.forward.normalized * -x * speed * Time.deltaTime * 50f);		
		rb.AddForce(orientation.right.normalized * y * speed * Time.deltaTime * 50f);
		
		jumptimer -= Time.deltaTime;
		
		if (isGrounded() && Input.GetKey (KeyCode.Space))
		{
			jumpvelocity = Mathf.Sqrt (jumpheight * -2 * Gravity);
			rb.AddForce(0,jumpvelocity,0, ForceMode.Impulse);
					
		}	
		
		if (rb.position.y < -10f) {
			//Death();
			Invoke ("Restart", 3);
		} 
		
		
		
		
	}
	
	public void Restart()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	/*public void Death()
	{
		Instantiate (death, rb.transform.position, rb.transform.rotation);
		Destroy (death, 5f);
	}
	*/
}
