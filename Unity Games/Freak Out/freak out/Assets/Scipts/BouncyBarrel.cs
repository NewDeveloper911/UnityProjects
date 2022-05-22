using UnityEngine;
using System.Collections;

public class BouncyBarrel : MonoBehaviour {

	public Rigidbody player;
	public BoomBarrel barrel;
	public float explosionForce;
	public float explosionRadius;

	void Start()
	{
		 explosionForce = barrel.explosionForce;
		 explosionRadius = barrel.explosionRadius;
	}
	
	void OnCollisionEnter()
	{
		player.AddExplosionForce(explosionForce,transform.position, explosionRadius);
	}
}
