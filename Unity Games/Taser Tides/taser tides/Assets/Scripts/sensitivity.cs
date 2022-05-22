using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sensitivity : MonoBehaviour {

	public AudioSource music;
	public Slider volumeslider;
	public Slider pitchslider;
	public Slider senseslider;
	public float rotationspeed; 


	void Update () {
		music = AudioManager.Instance.gameObject.GetComponent<AudioSource> ();
	}

	public void Volume()
	{
		music.volume = volumeslider.value;
	}
	public void Pitch()
	{
		music.pitch = pitchslider.value;
	}
	
	public void MouseSensitivity()
	{
		rotationspeed = senseslider.value;
	}

}
