using UnityEngine;
using System.Collections;

public class InkyAI : MonoBehaviour, IDamageable {

	public MonoBehaviour blin, clyde, pink;
	public float minTime = 1f;
	public float maxTime = 20f;
	public HealthManager health;
	public Timer timerscript;
	public GameManager game;
	[SerializeField]
	bool isTouchingPlayer;
	public LayerMask pacmanMask;
	
	void Awake()
	{
		health = GameObject.Find("HealthManager").GetComponent<HealthManager>();
		game = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Use this for initialization
	void Start () {
		StartCoroutine(ConstantlySwitchScriptsState(minTime, maxTime,blin));
		StartCoroutine(ConstantlySwitchScriptsState(minTime, maxTime, clyde));
		StartCoroutine(ConstantlySwitchScriptsState(minTime, maxTime, pink));
	}
	
	public void Damage()
	{
		health.Hurtinky(health.gundamage);	
	}
	
	/// <summary>
	/// Enables or Disables scripts depending on it's current state. Refreshes by random time.
	/// Don't turn off this the script itself if you don't want the switching to interrupt.
	/// You won't be able to enable it with itself.
	/// </summary>
	/// <param name="minWaitTime">Mininal random amount of time to wait until script changes it's state</param>
	/// <param name="maxWaitTime">Maximal random amount of time to wait until script changes it's state</param>
	/// <param name="scriptToSwitch">Reference to instance of the script</param>
	/// <returns>WaitForSeconds</returns>
	public static IEnumerator ConstantlySwitchScriptsState(float minWaitTime, float maxWaitTime, MonoBehaviour scriptToSwitch)
	{
		while (true)
		{
			scriptToSwitch.enabled = !scriptToSwitch.enabled;
			
			// Make sure that values are correct. You can check with "if" and "throw" an exception if you have to be sure that values the developer enter are definitely correct.
			minWaitTime = Mathf.Clamp(minWaitTime, 0, maxWaitTime);
			maxWaitTime = Mathf.Clamp(maxWaitTime, 0, maxWaitTime);
			
			yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
		}
	}
	
	//To start with, Blinky is active and the rest are inactive
	
	void Update()
	{
		if(blin.isActiveAndEnabled && pink.isActiveAndEnabled)
		{
			pink.enabled = false;
		}
		else if(clyde.isActiveAndEnabled && pink.isActiveAndEnabled )
		{
			clyde.enabled = false;
		}
		else if(blin.isActiveAndEnabled && clyde.isActiveAndEnabled)
		{
			blin.enabled = false;
		}
		else if (blin.isActiveAndEnabled && clyde.isActiveAndEnabled)
		{
			pink.enabled = false;
		}
		
		if (isTouchingPlayer && !game.IsSuperEatActive)
		{
			health.DamagePlayer(health.damage);
		}
		else if(isTouchingPlayer && game.IsSuperEatActive)
		{
			health.Hurtinky(health.inkhealth);
		}
	}
	
	void FixedUpdate()
	{
		isTouchingPlayer = Physics.CheckCapsule(transform.position + new Vector3(0,2.14f,0), transform.position + new Vector3(0,-2.14f,0), 3f, pacmanMask);	
	}
	
	void OnCollisionEnter(Collision info)
	{
		if(info.gameObject.tag == "Player" && timerscript.timer <= 0 && !game.IsSuperEatActive)
		{
			Damage();
		}
		else if(info.gameObject.tag == "Player" && timerscript.timer > 0 && game.IsSuperEatActive)
		{
			health.Hurtinky(health.inkhealth);
		}
	}
	
}