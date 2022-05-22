using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public Transform player;
	public Vector3 offset;
	[Range(10f, 200f)]
	public float rotationspeed = 100f;
	public Transform pivot;
	public bool offsetvalues;
	
	void Start () {
		transform.position = player.position - offset;
		if(offsetvalues)
		{
			offset = player.position - transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float horix = Input.GetAxis("Mouse X");
		player.Rotate (0,horix * rotationspeed * Time.deltaTime, 0);
		float yangle = player.eulerAngles.y;
		
		if (player.rotation.eulerAngles.x > 45f && player.rotation.eulerAngles.x < 270f) {
			player.rotation = Quaternion.Euler(45f,0,0);
		}
		
		float vertix = Input.GetAxis("Mouse Y");
		pivot.Rotate (vertix * rotationspeed * Time.deltaTime, 0,0);
		float xangle = pivot.eulerAngles.x;
		Quaternion rotation = Quaternion.Euler(xangle,yangle,0);
		transform.position = player.position - (rotation * offset);
		
		transform.LookAt (player);
		
		if (transform.position.y < player.position.y - 1) 
		{
			transform.position = new Vector3(transform.position.x, player.position.y - 1f, transform.position.z);
		}
	}
}
