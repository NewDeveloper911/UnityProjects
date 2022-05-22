using UnityEngine;
using System.Collections;

public class BoomBarrel : MonoBehaviour {

	public Rigidbody player;
	[Range(10, 10000)]
	public float explosionForce;
	[Range(1, 50)]
	public float explosionRadius;
	public Timer time;
	public float timeDeduction;
	public ParticleSystem explosion;
	
	void OnCollisionEnter()
	{
		player.AddExplosionForce(explosionForce, transform.position, explosionRadius);
		Instantiate(explosion, transform.position, transform.rotation);
		Destroy (gameObject);
		time.timer -= timeDeduction;
	}
}
