using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision info)
	{
		IDamageable damageable = (IDamageable)info.collider.GetComponent(typeof(IDamageable));
		if (damageable != null)
		{
			// I have hit a damageable object, namely the ghosts
			damageable.Damage();
		}
	}
	
}
