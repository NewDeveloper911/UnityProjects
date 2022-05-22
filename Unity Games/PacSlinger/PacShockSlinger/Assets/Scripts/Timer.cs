using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{ 
	public GameManager game;
	// a callback (like onClick for Buttons) for doing stuff when Countdown finished
	public UnityEvent OnCountdownFinished;
	
	// here the countdown runs later
	public float timer;
	
	public float timetaken;
	public string minutes, seconds;
	public Text timertext; 
	
	// for starting, pausing and stopping the countdown
	public bool runTimer;
	
	// just a control flag to avoid continue without pausing before
	private bool isPaused;
	
	// start countdown with duration
	public void StartCountdown(float duration) 
	{ 
		timer = duration; 
		runTimer = true;
		game.IsSuperEatActive = true;
	}
	
	// stop and reset the countdown
	public void StopCountdown()
	{
		ResetCountdown();
	}
	
	// pause the countdown but remember current value
	public void PauseCountdown()
	{
		if(!runTimer)
		{
			Debug.LogWarning("Cannot pause if not runnning");
			return;
		}
		
		runTimer = false;
		isPaused = true;
	}
	
	// continue countdown after it was paused
	public void ContinueCountdown()
	{
		if(!isPaused)
		{
			Debug.LogWarning("Countdown was not paused! Cannot continue if not started");
			return;
		}
		
		runTimer = true;
		isPaused = false;
	}
	
	private void Update() 
	{ 
		if(!game.HaveIWon && !game.gamehasended)
		{
			timetaken += Time.deltaTime;
		}
		minutes = ((int)timetaken / 60).ToString(); //Used if I wanted to display time
		seconds = (timetaken % 60).ToString("f2");
		timertext.text = minutes + " : " + seconds; 
		
		if (!runTimer) return;
		
		if (timer <= 0)
		{
			Finished();
		}
		
		// reduces the timer value by the time passed since last frame
		timer -= Time.deltaTime;

	} 
	
	
	private void ResetCountdown()
	{
		runTimer = false;
		isPaused = false;
		timer = 0;
		Debug.Log("Time's up, you poor malcontent");
	}
	
	// called when the countdown exceeds and wasn't stopped before
	private void Finished() 
	{ 
		// do what ever should happen when the countdown is finished
		
		// simpliest way is to call the UnityEvent and set up the rest via inspector
		// (same way as with onClick on Buttons)
		OnCountdownFinished.Invoke();
		
		// and reset the countdown
		ResetCountdown();
		
		game.IsSuperEatActive = false;
	} 
}
