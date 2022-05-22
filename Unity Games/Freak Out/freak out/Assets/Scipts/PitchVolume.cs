using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PitchVolume : MonoBehaviour {

	public Slider volumeslider;
	public Slider pitchslider;
	public AudioSource music;
	
	void Update()
	{
		music = AudioManager.Instance.gameObject.GetComponent<AudioSource>();
		
	}
	
	public void Volume()
	{
		music.volume = volumeslider.value;
	}
	
	public void Pitch()
	{
		music.pitch = pitchslider.value;

	}
}
