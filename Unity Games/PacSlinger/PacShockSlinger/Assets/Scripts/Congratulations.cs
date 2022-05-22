using UnityEngine;
using UnityEngine.UI;

public class Congratulations : MonoBehaviour {
	
	public Text credits1;
	public Text name;
	public bool doneWith = false;
	int creditlength;
	[SerializeField]
	string taletext;
	
	void Start () {
		creditlength = credits1.text.Length;
		taletext = credits1.text;
	}
	
	// Update is called once per frame
	void Update () {
		if (doneWith == false && Input.GetKey(KeyCode.Space)) {
			EnterName();
		}
	}
	
	public void TypeName()
	{
		if (credits1.text.Length > creditlength) {
			credits1.text = taletext;
			doneWith = false;
		}
	}
	
	
	public void EnterName()
	{
			credits1.text = name.text + ", huh? Well, let me tell the story. \n" + name.text + ", aka Pac-Man, was the one who single-handedly freed themself from the grasp of the wicked ghosts out for blood and did them in once and for all with their trusty revolver in a time of " + PlayerPrefs.GetString("EscapeTime", "00:00") +  " and with a score of " + PlayerPrefs.GetInt("FinalScore", 69420).ToString() + " points. Truly epic. However, their efforts may have been in vain\nI like the sound of that";
			doneWith = true;
	}
	
	public void BackToStart()
	{
		Debug.Log ("Back to the haunted mansion we go");
		Application.LoadLevel(0); // Go back to the haunted house again
	}
	
	public void Quit()
	{
		Debug.Log("I quit");
		Application.Quit();
	}
}

