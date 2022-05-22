using UnityEngine;
using System.Collections;

public class WaterRise : MonoBehaviour {

	public float timer, timertime;
	public Transform water;
	public GameManager game;
	
	void Start()
	{
		timer = timertime;
	}
	
	void Update()
	{
		/*	timer -= Time.deltaTime;
			
		if(timer <= 0)
		{
			water.position += new Vector3(0,3,0);
			timer = timertime;
		}
		*/
		
		water.position += new Vector3(0, timer * Time.deltaTime,0);
	}
	
	void OnCollisionEnter()
	{
		Debug.Log ("Contact is made");
		game.EndGame();
	}
}
