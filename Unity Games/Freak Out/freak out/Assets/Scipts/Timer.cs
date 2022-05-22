using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public GameManager game;
	public Text timertext;
	public float timer ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		timertext.text = "Time left: " + game.timer.ToString("0");
		if (timer <= 0)
		{
			game.EndGame();
			timer = 0;
		}
	
	}
}
