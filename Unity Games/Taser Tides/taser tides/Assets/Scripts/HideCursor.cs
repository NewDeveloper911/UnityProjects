using UnityEngine;
using System.Collections;

public class HideCursor : MonoBehaviour {

	bool isLocked = true;
	
	void Update()
	{
		if(Input.GetKeyDown (KeyCode.Escape))
		{
			SetCursor(!isLocked);	
		}
		else
		{
			SetCursor(isLocked);
		}
	}
	
	public void SetCursor(bool Locked)
	{
		this.isLocked = Locked;
		Screen.lockCursor = Locked;
		Screen.showCursor = !Locked;
	}
}
