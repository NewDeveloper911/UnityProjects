using UnityEngine;
using System.Collections;

public class CameraChange : MonoBehaviour {

	public Camera FpsCamera;
	public Camera TPsCamera;
	//public float targetFov;
	public int cammode;
	
	// Update is called once per frame
	void Update () {
		MyCamChanger();
	}
	
	void MyCamChanger()
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			
			StartCoroutine(CamChanger());
		}
	}
	IEnumerator CamChanger()
	{
		yield return new WaitForSeconds(0.01f);
		TPsCamera.enabled = !TPsCamera.enabled;
		FpsCamera.enabled = !FpsCamera.enabled;
	}
	
}
