using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	
	float xrotation = 0f;
	float yrotation = 0f;
	[Range(1, 300)]
	public float sensitivity;
	[SerializeField]
	Vector3 offset;
	public Transform pacman;
	
	void Start () {
		transform.position = pacman.position;
	}
	
	
	void Update () {
		
		float horiz = Input.GetAxis ("Mouse X") * sensitivity * Time.deltaTime;
		float vertical = Input.GetAxis ("Mouse Y") * sensitivity * Time.deltaTime;
		
		
		xrotation = Mathf.Clamp (xrotation, -28f, 71f);
		pacman.Rotate (Vector3.up * horiz);
		xrotation = pacman.eulerAngles.y;
		
		yrotation -= vertical;
		yrotation = Mathf.Clamp (yrotation, -61f, 61f);
		transform.localEulerAngles = new Vector3(yrotation,0,0);
		
		
		Quaternion rotation = Quaternion.Euler (0, xrotation, 0); // Actual rotation of camera
		transform.position = pacman.position - (rotation * (offset));
		
	}

}
