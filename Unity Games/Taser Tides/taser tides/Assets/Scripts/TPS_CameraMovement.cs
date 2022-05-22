using UnityEngine;
using System.Collections;

public class TPS_CameraMovement : MonoBehaviour {

	public Transform player, pivot;
	[Range(10f, 250f)]
	public float rotationspeed = 200f;
	public Vector3 offset;
	
	void Start()
	{
		pivot.position = player.position;
	}
	
	void Update()
	{
		float horiz = Input.GetAxis("Mouse X");
		float vert = Input.GetAxis ("Mouse Y");
		
		player.Rotate(0, horiz * rotationspeed * Time.deltaTime, 0);
		pivot.Rotate(vert * rotationspeed * Time.deltaTime, 0, 0);
		
		float yangle = player.eulerAngles.y;
		float xangle = player.eulerAngles.x;
		
		Quaternion rotation = Quaternion.Euler (xangle, yangle, 0);
		transform.position = player.position - (rotation * offset);
	}
	
}
