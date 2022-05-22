using UnityEngine;
using System.Collections;

public class HideCursor : MonoBehaviour {
	bool isLocked = true; // Automatically locks my cursor
	
	// Use this for initialization
	public void SetCursor (bool isLocked) {
	this.isLocked = isLocked;
	Screen.lockCursor = isLocked;  // Setting my isLocked variable to the premade boolean values
	Screen.showCursor = !isLocked;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
		{
			 //Locks and unlocks cursor when escape key is pressed
			 SetCursor(!isLocked);
		}
		else
		{
			SetCursor(isLocked);
		}
	}
}
