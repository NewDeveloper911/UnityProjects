using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {
	
	public GameManager game;
	public Consumption eat;
	public GameObject lowHealth;
	[Range(1, 20)]
	public int damage, gundamage;
	public int curhealth, blinkhealth, inkhealth, pinkyhealth, clydehealth;
	public int MaxPacHealth, MaxGhostHealth;
	bool amIdead = false;

	// Use this for initialization
	void Start () {
		blinkhealth =MaxGhostHealth;
		inkhealth = MaxGhostHealth;
		pinkyhealth = MaxGhostHealth;
		clydehealth = MaxGhostHealth;
		
		curhealth = MaxPacHealth;
	}
	
	public void DamagePlayer(int damage)
	{
		curhealth -= damage;
		if(curhealth - damage <= 0)
		{
			curhealth = 0;
		}
	}
	
	public void HealPlayer(int manna)
	{
		curhealth += manna;
		if(curhealth > MaxPacHealth)
		{
			curhealth = MaxPacHealth;
		}
	}
	
	
	//Deals with Clyde only for now
	public void KillClyde(int damage)
	{
		clydehealth -= damage;
		if (clydehealth <= 0)
		{
			KillClyde();
			clydehealth = MaxGhostHealth;
		}
	}
	
	
	void KillClyde()
	{
		eat.clyde.renderer.enabled = false;
		Debug.Log("One ghost down");
		game.clyde.transform.position = new Vector3(-13.34f, 13.4f, 14f);
		Invoke("Respawn", 3f);
	}
	
	void Respawn()
	{
		eat.clyde.renderer.enabled = true;
		clydehealth = MaxGhostHealth;
	}
	
	//Deals with BLinky for now
	public void HurtBlinky(int damage)
	{
		blinkhealth -= damage;
		if (blinkhealth <= 0)
		{
			KillBlinky();
			blinkhealth = MaxGhostHealth;
		}
	}
	
	
	void KillBlinky()
	{
		eat.blinky.renderer.enabled = false;
		Debug.Log("One ghost down");
		game.blinky.transform.position = new Vector3(-49.2f, 2f, 27f);
		Invoke("RespawnBlinky", 3f);
	}
	
	void RespawnBlinky()
	{
		eat.blinky.renderer.enabled = true;
		blinkhealth = MaxGhostHealth;
	}
	
	//deals with Inky for now
	public void Hurtinky(int damage)
	{
		inkhealth -= damage;
		if (inkhealth <= 0)
		{
			KillInky();
			inkhealth = MaxGhostHealth;
		}
	}
	
	
	void KillInky()
	{
		eat.inky.renderer.enabled = false;
		Debug.Log("One ghost down");
		game.inky.transform.position = new Vector3(-75f, 2f, 27f);
		Invoke("RespawnInky", 3f);
	}
	
	void RespawnInky()
	{
		eat.blinky.renderer.enabled = true;
		inkhealth = MaxGhostHealth;
	}
	
	//Deals with Pinky for now
	public void HurtPinky(int damage)
	{
		pinkyhealth -= damage;
		if (pinkyhealth <= 0)
		{
			KillPinky();
			pinkyhealth = MaxGhostHealth;
		}
	}
	
	
	void KillPinky()
	{
		eat.pinky.renderer.enabled = false;
		Debug.Log("One ghost down");
		game.pinky.transform.position = new Vector3(85.02f, 2.4f, 30f);
		Invoke("RespawnPinky", 3f);
	}
	
	void RespawnPinky()
	{
		eat.pinky.renderer.enabled = true;
		pinkyhealth = MaxGhostHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (curhealth <= 0)
		{
			amIdead = true;
			if(amIdead)
			{
				lowHealth.SetActive(false);
				game.GameOver();
			}
		}
		else if(curhealth < (MaxPacHealth / 5))
		{
			//Activates the UI when dying 
			lowHealth.SetActive(true);
		}
		else
		{
			lowHealth.SetActive(false);
		}
	}
}
