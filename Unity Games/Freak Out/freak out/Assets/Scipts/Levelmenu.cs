using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Levelmenu : MonoBehaviour {
	
	public GameManager game;
	public Button[] levelbuttons;
	public int levelReached;
	
	void Start()
	{
		int LevelReached = PlayerPrefs.GetInt("LatestLevel", 1);
		for(int i = 0; i < levelbuttons.Length; i++)
		{
			if(i + 1 > LevelReached)
			{
				levelbuttons[i].interactable = false;
			}
			else if(i + 1 < LevelReached)
			{
				levelbuttons[i].interactable = true;
			}
		}
	}
	
	void Update()
	{
		int LevelReached = PlayerPrefs.GetInt("LatestLevel");
	}
	
	
}
