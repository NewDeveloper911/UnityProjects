using UnityEngine;
using System.Collections;

public class ChooseSong : MonoBehaviour {

	public AudioClip boombox;
	public AudioClip chacha;
	public AudioManager audio;
	
	public void Boombox()
	{
		audio.SongChoice(boombox);
	}
	
	public void Chacha()
	{
		audio.SongChoice(chacha);
	}
	
}
