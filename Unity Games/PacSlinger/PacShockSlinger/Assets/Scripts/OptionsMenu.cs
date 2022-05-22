using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {

	public Slider senslider, audioslider, sfxslider;
	public FollowPlayer cam;
	public AudioSource music;
	[SerializeField]
	float vol,sfxvol;
	public List<AudioSource> sfxSources;
	
	// Use this for initialization
	void Awake () 
	{	
		senslider.maxValue = 300f;
	}
	
	void LateUpdate()
	{
		music = AudioManager.Instance.gameObject.GetComponent<AudioSource>();
		vol = music.volume;
	}
	
	public void VolumeChanger()
	{
		music.volume = vol;
	}
	
	public void Selectlevel(int i)
	{
		Application.LoadLevel(i);
	}
	
	// Update is called once per frame
	void Update () 
	{
		cam.sensitivity = senslider.value;
		music.volume = audioslider.value;
		foreach (AudioSource i in sfxSources)
		{
			i.volume = sfxslider.value;//Changes the volume of each Sfx audioSource
			sfxvol = i.volume;	
		}
		
	}
}
