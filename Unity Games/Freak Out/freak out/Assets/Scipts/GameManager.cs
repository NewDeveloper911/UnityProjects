using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	bool gameHasEnded = false;
	public float timer = 10f;
	public Timer timertime;
	public float restartDelay = 3f;
	public HideCursor curse;
	public GameObject PauseMenuUI;
	public GameObject completelevelUI;
	public GameObject timeupUI;
	

	
	public void CompleteLevel()
	{
		completelevelUI.SetActive (true);
		PlayerPrefs.SetInt("LatestLevel", Application.loadedLevel + 1);
		Invoke("nextLevel", restartDelay);
		curse.SetCursor(Screen.showCursor);
		
	}
	
	public void EndGame ()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			Debug.Log ("GAME OVER");
			timeupUI.SetActive(true);
			Invoke("Restart", restartDelay);
		}
	}
	void Restart()
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
		
		timer = timertime.timer;
		if (timer <= 0)
		{
			EndGame();	
		}
	}
	
	public void nextLevel()
	{
		Application.LoadLevel("main menu");
	}
	
	public void Pause()
	{
		Time.timeScale = 0f;
		PauseMenuUI.SetActive(true);
	}
	
	public void Continue()
	{
		Time.timeScale = 1f;
		PauseMenuUI.SetActive(false);
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
		Application.LoadLevel ("main menu");
	} 
	
	public void NextLevelINGAme()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void LevelLoader(int LevelNum)
	{
		Application.LoadLevel(LevelNum);
	}
	
	
	
	
}

