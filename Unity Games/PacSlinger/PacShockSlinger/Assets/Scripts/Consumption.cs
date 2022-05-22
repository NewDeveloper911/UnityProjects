using UnityEngine;

public class Consumption : MonoBehaviour {
	
	public GameManager game;
	public Timer timerscript;
	public GameObject pickupeffect, bonuseffect;
	public Material ediblematerial, blinmaterial, inkmaterial, clydematerial, pinkmaterial;
	public MeshRenderer blinky,pinky,clyde,inky;
	public int pelletpower;
	[SerializeField]
	[Range(0, 2)]
	float lifetime;
	public float dinnertime;
	public HealthManager health;
	
	void Awake()
	{
		game = GameObject.Find("GameManager").GetComponent<GameManager>();
		health = GameObject.Find("HealthManager").GetComponent<HealthManager>();
		pickupeffect = GameObject.Find("MunchABunch");
		timerscript = GameObject.Find("GameManager").GetComponent<Timer>();
		blinky = GameObject.Find("Blinky").GetComponentInChildren<MeshRenderer>();
		pinky = GameObject.Find("Pinky").GetComponentInChildren<MeshRenderer>();
		clyde = GameObject.Find("Clyde").GetComponentInChildren<MeshRenderer>();
		inky = GameObject.Find("Inky").GetComponentInChildren<MeshRenderer>();
		bonuseffect = GameObject.Find("BonusItemFound");
	}
	
	void OnTriggerEnter(Collider other)
	{
	
		if(other.tag == "Player")
		{
			if (this.gameObject.name == "PowerPellets")
			{
				game.foodeaten++;
				//Starts the Frightned timer
				if(!timerscript.runTimer)
				{
					timerscript.StartCountdown(dinnertime);
				}
				else
				{
					timerscript.ContinueCountdown();
				}
				
				//Code which will make the ghosts unable to shoot or attack is above
				game.score += pelletpower;
				GameObject ps = Instantiate(pickupeffect, transform.position, Quaternion.identity) as GameObject;
				//Destroy(this.gameObject);
				this.gameObject.renderer.enabled = false;
				Destroy(ps, lifetime);
				Destroy(this.gameObject, dinnertime + 0.1f);
			}
			else if(this.gameObject.name == "pellets")
			{
				game.foodeaten++;
				game.score += pelletpower;
				GameObject ps = Instantiate(pickupeffect, transform.position, Quaternion.identity) as GameObject;
				Destroy(this.gameObject);
				Destroy(ps, lifetime);
			}
			else
			{
				//I have found a bonus item, so I want to indicate that with a different particle system
				game.score += pelletpower;
				GameObject bonusps = Instantiate(bonuseffect, transform.position, Quaternion.identity) as GameObject;
				Destroy(this.gameObject);
				Destroy(bonusps, lifetime);
				health.HealPlayer(health.MaxPacHealth);
			}
		}
	}
	
	void Update()
	{
		if (timerscript.timer > 0)
		{
			//Code which will execute when enabled and still within the timer limit
			Debug.Log("Spooky scary skeletons... and ghosts");
			//game.IsSuperEatActive = true;
			blinky.material = ediblematerial;
			clyde.material = ediblematerial;
			inky.material = ediblematerial;
			pinky.material = ediblematerial;
		}
		else
		{
			//Now that the timer has run out, this should rtigger
			Debug.Log("I have reset the materials");
			blinky.material = blinmaterial;
			clyde.material = clydematerial;
			pinky.material = pinkmaterial;
			inky.material = inkmaterial;
		}
	}
	
	
}
