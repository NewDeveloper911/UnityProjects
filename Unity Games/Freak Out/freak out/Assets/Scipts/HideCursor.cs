using UnityEngine;
using System.Collections;

public class HideCursor : MonoBehaviour {
	
	bool isLocked = true;
	
	void Start()
	{
		SetCursor(Screen.showCursor);
	}
	
	public void SetCursor(bool isLocked)
	{
		this.isLocked = isLocked;
		Screen.lockCursor = isLocked;
		Screen.showCursor = !isLocked;
	}
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			SetCursor(!isLocked);
		} else 
		{
			SetCursor(isLocked);
			
		}
	}
}