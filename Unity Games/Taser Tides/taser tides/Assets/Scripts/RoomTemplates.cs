using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] rooms;
	public List<GameObject> roomcollect;
	public float WaitTime;
	public WaterRise water;
	
	
	void Start()
	{
		WaitTime = water.timertime / Time.deltaTime;
	}
	void Update()
	{
		if(WaitTime <= 0)
		{
			Destroy(roomcollect[0]);
		}
		else
		{
			WaitTime -= Time.deltaTime;
		}
	}
}
