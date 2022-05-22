using UnityEngine;
using System.Collections;

public class CompleteLevel : MonoBehaviour {

	public GameManager game;
	public RoomTemplates roomies;
	int random;
	public float heightincrease = 100f;
	bool spawned = false;
	public GameObject croom2;
	public GameObject entry;
	
	void OnTriggerEnter()
	{
		game.CompleteLevel();
		/*
		if(spawned == false)
		{
			random = Random.Range(0, roomies.rooms.Length);
			Instantiate(roomies.rooms[random], entry.transform.position +  new Vector3(0, heightincrease, 0), Quaternion.identity);
			heightincrease += 100f;
			spawned = true;
		} */
	}
}
