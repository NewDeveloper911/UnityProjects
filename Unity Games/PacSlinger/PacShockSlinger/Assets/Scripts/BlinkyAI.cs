using UnityEngine;
using System.Collections;

public class BlinkyAI : MonoBehaviour, IDamageable {
	
	public NavMeshAgent ghost;
	public GameManager game;
	public Timer timerscript; 
	public Transform pacman;
	public HealthManager health;
	public GameObject projectile;
	public LayerMask groundMask, pacmanMask;
	
	//Used for my patrolling state
	public Vector3 walkpoint;
	public bool walkpointSet = false;
	public float walkpointRange;
	
	//Used for my attacking states
	public float TimeBetweenAttacks;
	[SerializeField]
	bool alreadyAttacked,speedBoostbool, isTouchingPlayer = false;
	[SerializeField]
	float attackInaccuracy, timer, speedBoost;
	
	[Range(1,30)]
	public float attackRange;
	[Range(1,100)]
	public float sightRange;
	public bool playerInSightRange, playerInIdleRange;
	[Range(1, 200)]
	public float projectileRange;
	
	//Audio function used for audio enhancement
	public AudioClip chaseSFX, normSFX;
	public AudioSource music;
	public AudioManager audioman;
	
	// Use this for initialization
	void Awake () {
		pacman = GameObject.Find("pacman").transform;
		game = GameObject.Find("GameManager").GetComponent<GameManager>();
		timerscript = GameObject.Find("GameManager").GetComponent<Timer>();
		timer = TimeBetweenAttacks;
		audioman = GameObject.Find("AudioManager").GetComponent<AudioManager>();
	}
	
	//Using a written interface, I am going to damage the ghost if shot or in contact with player during Frightened mode
	public void Damage()
	{
		//This has to be public as interfaces only use the public accessor
		health.HurtBlinky(health.gundamage);
	}
	
	// Update is called once per frame
	void Update () {
		//Checks to see if pacman is is sight and/or attack range
		//Attack range must be less than sight range - Can't attack what you can't see
		playerInSightRange = Physics.CheckSphere(transform.position, sightRange, pacmanMask);
		playerInIdleRange = Physics.CheckSphere(transform.position, attackRange, pacmanMask);
		isTouchingPlayer = Physics.CheckCapsule(transform.position + new Vector3(0,2.14f,0), transform.position + new Vector3(0,-2.14f,0), 3f, pacmanMask);
		if(!playerInSightRange && !playerInIdleRange)
		{
			//If we can't see or attack player
			Patrolling();
			music.Pause();
			music.clip = normSFX;
			music.Play();
		}
		else if(playerInSightRange && !playerInIdleRange)
		{
			//If we can see but not attack player
			Chasing();
			music.Pause();
			music.clip = chaseSFX;
			music.Play();
		}
		else if(playerInSightRange && playerInIdleRange )
		{
			//If we can see and attack player
			Attacking();
		}
		
		if (isTouchingPlayer && !game.IsSuperEatActive)
		{
			health.DamagePlayer(health.damage);
		}
		else if(isTouchingPlayer && game.IsSuperEatActive)
		{
			health.HurtBlinky(health.blinkhealth);
			game.score += 100;
		}
		//Speed boost is applied when PacMan has eaten a certain fraction of cookies
		if((game.foodeaten / game.foodleft) >= 0.5f)
		{
			if(!speedBoostbool)
			{
				//Activates when PacMan has eaten half of the fruit
				speedBoostbool = true;
				if(speedBoostbool)
				{
					ghost.speed += speedBoost;
					speedBoostbool = false;
				}
				speedBoostbool = true;
			}
		}
	}
	
	public void Patrolling()
	{
		if(!walkpointSet)
		{
		 SearchWalkPoint();
		}
		else
		{
			ghost.SetDestination(walkpoint);
		}
		
		Vector3 distanceToWalkPoint = transform.position - walkpoint;
		if(distanceToWalkPoint.magnitude <1f)
		{
			//We have reached our destination
			walkpointSet = false;
		}
	}
	
	void SearchWalkPoint()
	{
		float randomZ = Random.Range(-walkpointRange, walkpointRange);
		float randomX = Random.Range(-walkpointRange, walkpointRange);
		walkpoint = transform.position + new Vector3(randomX, 0, randomZ);
		
		if(Physics.Raycast(walkpoint, -transform.up,2f, groundMask))
		{
			walkpointSet = true;
		}
	}
	
	public void Attacking()
	{
		//Stop moving
		ghost.SetDestination(transform.position);
		transform.LookAt(pacman);
		if(!alreadyAttacked && !isTouchingPlayer)
		{	
			//Add my attack code here
			EctoCannon();
			//
			alreadyAttacked = true;
			Invoke("ResetAttack", TimeBetweenAttacks);
		}
		else if(alreadyAttacked)
		{
			Invoke("ResetAttack", TimeBetweenAttacks);
		}
	}
	
	
	void ResetAttack()
	{
		alreadyAttacked = false;
		Debug.Log("Attack should be reset now. If not, we have a problem");
	}
	
	public void Chasing()
	{
		ghost.SetDestination(pacman.position);
	}
	
	void OnDrawGizmosSelected()
	{
		//This just makes everything more visual
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(transform.position, sightRange);
	}
	
	public void EctoCannon()
	{	
		if (timer <= 0 && Time.timeScale == 1f)
		{
			GameObject curbullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
			Projectile pro = curbullet.GetComponent<Projectile>();
			pro.origin = transform.position;
			pro.target = pacman.position;
			timer = TimeBetweenAttacks;
			pro.DestroyProjectile(curbullet, 2);
		}
		else
		{
			timer -= Time.deltaTime;
		}
	}
		 
	
	void OnCollisionEnter(Collision info)
	{
		if(info.gameObject.tag == "Player" && timerscript.timer <= 0 && !game.IsSuperEatActive)
		{
			health.DamagePlayer(health.curhealth);
			Debug.LogWarning("Clyde is murdering us"); 
		}
		else if (info.gameObject.tag == "Player" && timerscript.timer > 0)
		{
			health.HurtBlinky(health.blinkhealth); //Instakills the ghost on contact
		}
		
	}
	
}
