using UnityEngine;
using System.Collections;

public class ReloadScript : MonoBehaviour {

	public Gun gunscript;
	
	// Use this for initialization
	void Start () {
		gunscript = GameObject.Find("revolver").GetComponent<Gun>();
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			gunscript.Reload();
			Debug.Log("Successfully reloaded my gun");
			gameObject.collider.enabled = false;
			gameObject.renderer.enabled = false;
		}
	}
}
