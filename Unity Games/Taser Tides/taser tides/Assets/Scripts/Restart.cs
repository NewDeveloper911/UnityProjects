using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {
	
	
	public GameManager game;
	
	void OnCollisionEnter()
	{
		game.Restart();
	}
}
