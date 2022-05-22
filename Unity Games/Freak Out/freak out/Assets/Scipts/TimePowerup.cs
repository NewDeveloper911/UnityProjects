using UnityEngine;
using System.Collections;

public class TimePowerup : MonoBehaviour {

	public Timer clock;
	public ParticleSystem health;
	public float healthpowerup;
	[Range(0, 5f)]
	public float lifetime = 0.2f;
	
	void OnTriggerEnter()
	{
		clock.timer += healthpowerup;
		Instantiate(health, transform.position, Quaternion.identity);
		Destroy(gameObject, lifetime);
		Destroy (health, lifetime);
	}
}
