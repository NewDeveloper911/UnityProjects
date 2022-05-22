using UnityEngine;
using System.Collections;

public class trap : MonoBehaviour, IDamageable {

	public Animator animate;
	public HealthManager health;
	
	// Use this for initialization
	void Start () {
		animate = GetComponent<Animator>();
		health = GameObject.Find("HealthManager").GetComponent<HealthManager>();
		animate.SetBool("Kill", false);
	}
	
	void OnTriggerEnter(Collider trig)
	{
		if(trig.gameObject.CompareTag("Player"))
		{
			animate.Play("TrapTrigger");
			health.DamagePlayer(health.curhealth);
			Debug.LogWarning("Noob got caught in a trap");
			animate.SetBool("Kill", true);
		}
	}
	
	public void Damage()
	{
		Destroy(this.gameObject);
		Debug.Log("looks like VSauce is deploying his pro-gamer moves");
	}
}
