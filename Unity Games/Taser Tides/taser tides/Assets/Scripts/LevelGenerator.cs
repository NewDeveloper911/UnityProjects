using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {
	[SerializeField] Transform startLevel;
	[SerializeField] Transform levelPart1;
	int startingPlatforms = 5;
	private void Awake()
	{	
		Transform lastlevelPartTransform;
		lastlevelPartTransform = SpawnLevelPart(startLevel.Find("EndPosition").transform.position);
		lastlevelPartTransform = SpawnLevelPart(lastlevelPartTransform.Find("EndPosition").transform.position);
		lastlevelPartTransform = SpawnLevelPart(lastlevelPartTransform.Find("EndPosition").transform.position);
		lastlevelPartTransform = SpawnLevelPart(lastlevelPartTransform.Find("EndPosition").transform.position);
		lastlevelPartTransform = SpawnLevelPart(lastlevelPartTransform.Find("EndPosition").transform.position);
		lastlevelPartTransform = SpawnLevelPart(lastlevelPartTransform.Find("EndPosition").transform.position);
		
	}
	
	private Transform SpawnLevelPart(Vector3 spawnpoint)
	{
		Instantiate(startLevel, spawnpoint, Quaternion.identity);
		Transform levelPartTransform = startLevel.GetComponent<Transform>();
		return levelPartTransform;
	}
	
}
