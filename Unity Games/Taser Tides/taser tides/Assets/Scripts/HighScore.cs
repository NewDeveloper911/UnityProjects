using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public Text highscore;
	public GameManager game;
	public Text CurrentScore;
	public int score;
	public int highscorenum;
	public int increment = 1;
	public int newhighscore;
	float startheight;
	public Transform player;
	
	void Start()
	{
		startheight = player.transform.position.y;
	}
	
	void Update()
	{
		highscore.text = "Highscore: " + highscorenum.ToString("0");
		highscorenum = PlayerPrefs.GetInt("Highscore");
		
		if(game.gameoverUI.activeSelf == false)
		{
			if(Time.timeScale == 1f)
			{
			score += increment;
			CurrentScore.text = "Score: " + score.ToString("0");
			}
		}
		
		if(game.gameoverUI.activeSelf == true)
		{
			score = score;
			
			//PlayerPrefs.SetInt ("Highscore", int.Parse(CurrentScore.text));
			
			if (score > highscorenum) 
			{
				newhighscore = score;
				PlayerPrefs.SetInt ("Highscore", newhighscore);
			}
			else if (highscorenum > score) 
			{
				PlayerPrefs.SetInt("Highscore",highscorenum);
			}
		}
	}
	
}
