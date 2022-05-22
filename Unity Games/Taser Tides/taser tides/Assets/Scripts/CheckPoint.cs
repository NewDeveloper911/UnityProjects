using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public Renderer visual;
	public Material Unreached, Reached;
	
	
	void Start()
	{
		visual.material = Unreached;
	}
	
	void OnCollisionEnter()
	{
		ChangeMaterial();
		
	}
	
	void ChangeMaterial()
	{
		visual.material = Reached;
	}
}
