using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed;
	public Transform pacman, ghost;
	public HealthManager health;
	[SerializeField]
	Rigidbody rb;
	public Vector3 target, origin;
	[SerializeField]
	float StartTime;
	public GameManager game;
	
	// Use this for initialization
	void Start () {
		pacman = GameObject.FindGameObjectWithTag("Player").transform;
		target = pacman.position;
		origin = transform.position;
		health = GameObject.Find("HealthManager").GetComponent<HealthManager>();
		rb = GetComponent<Rigidbody>();
		game = GameObject.Find("GameManager").GetComponent<GameManager>();
		speed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		//float fracJourney = (Time.time - StartTime) * speed;
		transform.LookAt(pacman);
		rb.AddForce(transform.forward * speed, ForceMode.Impulse);
		rb.AddForce(transform.up * (speed / 5f), ForceMode.Impulse);
		//transform.position = Vector3.Lerp(origin, target, speed * Time.deltaTime);
		
	}
	
	public void DestroyProjectile(GameObject obj, int destructiontime)
	{
		Destroy(obj, destructiontime);
		Debug.Log("Now, the object would have been destroyed");
	}
	
	void OnCollisionEnter(Collision info)
	{
		if(info.gameObject.CompareTag("Player") && !game.IsSuperEatActive)
		{
			health.DamagePlayer(health.damage);
			
		}
	}
}
