using UnityEngine;
using System.Collections;

public class CompleteLevel : MonoBehaviour {

	public GameManager game;
	public Levelmenu level;
	
	
	void Start()
	{
		level = GetComponent<Levelmenu>();
	}
	void OnTriggerEnter()
	{
		game.CompleteLevel();
	}
}
