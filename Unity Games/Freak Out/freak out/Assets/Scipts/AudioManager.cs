using UnityEngine;


public class AudioManager : MonoBehaviour {
	
	private static AudioManager instance = null;
	private bool isPaused = false;
	public AudioSource music;
	
	public static AudioManager Instance
	{
		get{return instance;}
	}
	
	 void Awake()
	{
		if (instance != null && instance != this) 
		{
			Destroy (this.gameObject);
		} 
		else 
		{
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);

		music = AudioManager.Instance.gameObject.GetComponent<AudioSource>();
		
	}
	
	 void Update () 
	{
		if (Input.GetKey ("p")) 
		{
			if(isPaused)
			{
				music.Pause();
			}
			else
			{
				isPaused = !isPaused;
				music.Play();
			}
		}
	}
	
	public void SongChoice(AudioClip song)
	{
		if(song != null)
		{
			music.clip = song;
			music.Play();
		}
	}
}
