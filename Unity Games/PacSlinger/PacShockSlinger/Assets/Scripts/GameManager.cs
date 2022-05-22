using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public GameObject pacman,inky,blinky,pinky,clyde;
	[SerializeField]
	public Vector3 pacpos, inkpos, blinpos, pinpos, clypos;
	public HealthManager health;
	public GameObject gameoverUI, pausemenuUI, bulletUI, timerUI;
	public CharacterMovement movement;
	public bool gamehasended = false;
	public GameObject pelletmodel, powerpelletmodel;
	public List<GameObject> food;
	public int foodeaten, foodleft, score, newhighscore;
	public bool IsSuperEatActive = false;
	public Timer timer;
	[SerializeField]
	float timeleft;
	public HideCursor curses;
	public bool HaveIWon = false;
	public Text scoretext;
	
	void Awake()
	{
		IsSuperEatActive = false;
		health = GameObject.Find("HealthManager").GetComponent<HealthManager>();
		gamehasended = false;
		GameObject[] a = GameObject.FindGameObjectsWithTag("Food");
		food.AddRange(a);
		foodleft = food.Count;
		foodeaten = 0;
	}
	
	void Start()
	{
		if (newhighscore != 0 || newhighscore != null)
		{
			newhighscore = PlayerPrefs.GetInt("HighScore", 1);
		}
		else
		{
			newhighscore = PlayerPrefs.GetInt("HighScore");
		}
	}
	
	// Update is called once per frame
	void Update () {
		timeleft = timer.timer;
	
		if (pacman != null)
		{
			pacpos = pacman.transform.position;
		}
		if (blinky != null)
		{
			blinpos = blinky.transform.position;
		}
		if (inky != null)
		{
			inkpos = inky.transform.position;
			if (pinky != null)
			{
				pinpos = pinky.transform.position;
				if (clyde != null)
				{
					clypos = clyde.transform.position;
				}
			}
		}
		
		//Activates the pause menu
		if(Input.GetKey(KeyCode.LeftShift))
		{
			pausemenuUI.SetActive(true);
		}
		
		if (foodeaten >= food.Count)
		{
			//If I have somehow managed to eat all of the food
			HaveIWon = true;
			PlayerPrefs.SetString("EscapeTime", timer.minutes + " : " + timer.seconds);
			PlayerPrefs.SetInt("FinalScore", score);
			Application.LoadLevel(2); //Loads the final scene for those who manage to win
		}
		else
		{
			HaveIWon = false;
		}
	}
	
	
	public void GameOver()
	{
		pausemenuUI.SetActive(false);
		gameoverUI.SetActive(true);
		movement.enabled = false;
		bulletUI.SetActive(false);
		timerUI.SetActive(false);
		gamehasended = true;
		HighScore();
	}
	
	public void HighScore()
	{
		if(score > newhighscore)
		{
			//Changes highscore if we beat it
			PlayerPrefs.SetInt("HighScore", score);
			newhighscore = score;
		}
		
		scoretext.text = "Your current score is: " + score.ToString() + "\n Your highscore is: " + newhighscore.ToString();
		
	}
	
	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void Pause()
	{
		curses.SetCursor(Screen.lockCursor);
		gameoverUI.SetActive(false);
		pausemenuUI.SetActive(true);
		bulletUI.SetActive(false);
		timerUI.SetActive(false);
		NavMeshAgent ink = inky.GetComponent<NavMeshAgent>();
		ink.Stop();
		NavMeshAgent bink = blinky.GetComponent<NavMeshAgent>();
		bink.Stop();
		NavMeshAgent pink = pinky.GetComponent<NavMeshAgent>();
		pink.Stop();
		NavMeshAgent cly = clyde.GetComponent<NavMeshAgent>();
		cly.Stop();
	}
	
	public void Continue()
	{
		curses.SetCursor(Screen.showCursor);
		gameoverUI.SetActive(false);
		pausemenuUI.SetActive(false);
		bulletUI.SetActive(true);
		timerUI.SetActive(true);
		Time.timeScale = 1f;
		NavMeshAgent ink = inky.GetComponent<NavMeshAgent>();
		ink.Resume();
		NavMeshAgent bink = blinky.GetComponent<NavMeshAgent>();
		bink.Resume();
		NavMeshAgent pink = pinky.GetComponent<NavMeshAgent>();
		pink.Resume();
		NavMeshAgent cly = clyde.GetComponent<NavMeshAgent>();
		cly.Resume();
	}
	
	public void BackToMenu()
	{
		Application.LoadLevel(0);
		//Loads the first level, which I always set as my main menu
	}
	
	
}
