﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour {
	
	//The bullet and its movement forces
	public GameObject bullet;
	public float shootForce, upwardForce;
	
	//Gun stats
	public float TimeBetweenShots,TimeBetweenShooting, spread, reloadtime;
	public int magazineSize, bulletsPerTap;
	public bool allowButtonHold;
	
	//How many bullets were shot and how many are left
	[SerializeField]
	int bulletsLeft, bulletShot;
	
	[SerializeField]
	bool shooting, readyToShoot, reloading, BulletsLeftAreGreaterThanZero;
	
	public Camera fpsCam;
	public Transform attackPoint;
	public LayerMask CanBeShot;
	
	//Graphics and visual effects
	public GameObject muzzleFlash;
	//public Animator GunAnimator //Might use if I want to play animations when firing and reloading
	public Text bulletUIText;
	public GameObject gunUI;
	
	//This is used to fix bugs, which I will defintely need
	public bool allowInvoke;
	
	// Use this for initialization
	void Awake () {
		bulletsLeft = magazineSize;
		readyToShoot = true;
	}
	
	void MyInput()
	{
		//Check if I can hold fire button (not really for revolvers)
		if (allowButtonHold) 
		{
			shooting = Input.GetMouseButton(0);
		}
		else
		{ 
			shooting = Input.GetMouseButtonDown(0);
		}
		
		//Triggering the reload functions
		/*
		if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
		{
			Reload();
			Debug.Log("You are quite impulsive, aren't you?");
		}
		
		if (readyToShoot && shooting && !BulletsLeftAreGreaterThanZero && !reloading)
		{
		 	Reload();
		 	Debug.Log("Ran out of bullets, fool");
		}
		*/
		
		//If I am able to shoot
		if (readyToShoot && shooting && !reloading && BulletsLeftAreGreaterThanZero)
		{
			bulletShot = 0;
			Shoot();
			Debug.Log("I have shot a bullet. What is happening?");
		}
	}
	
	public void Shoot()
	{
		readyToShoot = false;
		
		//Use a raycast to get location of bullet target
		Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;
		
		//Checks if the ray hit something
		Vector3 targetpoint;
		if (Physics.Raycast(ray, out hit, CanBeShot))
		{
			targetpoint = hit.point;
		}
		else{
			targetpoint = ray.GetPoint(420); //Sends ray far away
		}
		
		//Calculate direction from place of attack to targetpoint
		Vector3 directionWithoutSpread = targetpoint - attackPoint.position;
		
		//Calculate spread (for shotguns and those types of guns)
		float xSpread = Random.Range(-spread, spread);
		float ySpread = Random.Range(-spread, spread);
		
		//Calculates direction with spread
		Vector3 directionWithSpread = directionWithoutSpread + new Vector3(xSpread,ySpread,0);
		
		//Instantiate the bullet to be shot
		GameObject curbullet = Instantiate(bullet, attackPoint.position, Quaternion.FromToRotation(attackPoint.position, directionWithSpread.normalized)) as GameObject;
		
		//Rotates bullet to face direction of shooting
		curbullet.transform.forward = directionWithSpread.normalized;
		
		//Actually shoots the object
		curbullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
		Debug.DrawRay(attackPoint.position, directionWithSpread.normalized, Color.cyan);
		//If I want an upwards force
		curbullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);
		
		//Instantiates a muzzle flash if it exists, after i shoot
		if (muzzleFlash != null)
		{
			GameObject muzflash = Instantiate(muzzleFlash, attackPoint.position, Quaternion.FromToRotation(attackPoint.position, directionWithSpread.normalized)) as GameObject;
			Destroy(curbullet, TimeBetweenShots);
			Destroy(muzflash, TimeBetweenShots);
		}
		
		bulletsLeft--; // Used to decrement values
		bulletShot++;
		
		//Used to reload
		if (allowInvoke)
		{
			Invoke("ResetShot", TimeBetweenShooting);
			allowInvoke = false;
		}
		
		//If I want to shoot multiple bullets per Tap, e.g a shotgun
		if(bulletShot < bulletsPerTap && bulletsLeft > 0)
		{
			Invoke("Shoot", TimeBetweenShots);
		}
	}
	
	//Allows me to shoot again after some time
	void ResetShot()
	{
		readyToShoot = true;
		allowInvoke = true;
	}
	
	//Begins the process of reloading my gun
	public void Reload()
	{
		reloading = true;
		Invoke("ReloadFinished", reloadtime);
	}
	
	//Actual reloading of my gun
	void ReloadFinished()
	{
		bulletsLeft = magazineSize;
		reloading = false;
	}
	
	
	// Update is called once per frame
	void Update () {
		if (bulletsLeft <= 0) BulletsLeftAreGreaterThanZero = false;
		else BulletsLeftAreGreaterThanZero = true;
		MyInput();
		
		if(gunUI != null)
		{
			bulletUIText.text = (bulletsLeft / bulletsPerTap).ToString() + " / " + (magazineSize / bulletsPerTap).ToString();
		}
	}
}
