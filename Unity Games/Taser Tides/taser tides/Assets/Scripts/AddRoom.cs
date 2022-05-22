using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddRoom : MonoBehaviour {

	public RoomTemplates roomie;
	
	void Start () 
	{
		roomie = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemplates>();
		roomie.roomcollect.Add(this.gameObject);
	}
	
	
}
