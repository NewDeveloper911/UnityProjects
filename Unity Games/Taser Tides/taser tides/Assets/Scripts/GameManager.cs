using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	bool gameHasEnded = false;
	public FreePlayerMovement movement;
	public RoomTemplates roomies;
	public float restartDelay = 3f;
	int random;
	public GameObject PauseMenuUI;
	public GameObject croom2;
	public GameObject entry;
	public GameObject gameoverUI;
	public ParticleSystem drown;
	public HideCursor curses;
	public Transform player;
	public float lifetime = 0.5f;
	public float heightincrease = 100f;
	bool spawned = false;
	public WaterRise water;
	public HighScore score;
	
	void Start()
	{
		roomies = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemplates>();
		water = GameObject.Find("Water").GetComponent<WaterRise>();
		score = gameObject.GetComponent<HighScore>();
	}
	
	public void CompleteLevel()
	{
		Debug.Log ("Working fine, I thjink");
			random = Random.Range(0, roomies.rooms.Length);
			Instantiate(roomies.rooms[random], entry.transform.position +  new Vector3(0, heightincrease, 0), Quaternion.identity);
			heightincrease += 100f;
			spawned = true;
	}
	
	public void EndGame ()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			Debug.Log ("GAME OVER");
			Death();
			//Invoke("Death", restartDelay);
			gameoverUI.SetActive(true);
			curses.SetCursor(Screen.showCursor);
			movement.enabled = false;
		}
	}
	public void Restart()
	{
		
		Application.LoadLevel(Application.loadedLevel);
	}
	
	void Update()
	{
		if (Input.GetKey ("l")) 
		{
			Time.timeScale = 0f;
		}
		if (Input.GetKey ("m")) 
		{
			Time.timeScale = 1f;
		}
		
		if(Input.GetKey ("r"))
		{
			Invoke ("Restart", 2f);
		}
		
		
	}
	
	public void nextLevel()
	{
		Application.LoadLevel("Start menu");
	}
	
	public void Pause()
	{
		Time.timeScale = 0f;
		PauseMenuUI.SetActive(true);
		water.timer = 0;
		if(Time.timeScale == 0)
		{
			score.score -= score.increment;
		}
	}
	
	public void Continue()
	{
		Time.timeScale = 1f;
		PauseMenuUI.SetActive(false);
		water.timer = water.timertime;
		score.score += score.increment;
	}
	
	public void Quit()
	{
		Debug.Log("Quit");
		Application.Quit ();
	}
	
	public void BacktoMenu()
	{
		Application.LoadLevel(0);
	}
	
	public void SeeYa()
	{
		Application.LoadLevel ("Start menu");
	} 
	
	public void NextLevelINGAme()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void LevelLoader(int LevelNum)
	{
		Application.LoadLevel(LevelNum);
	}
	
	public void Death()
	{
		Instantiate(drown, player.position, new Quaternion(-0.7071068f,0,0,0.7071068f));
		Destroy(drown, lifetime);
	}
	
	
}

