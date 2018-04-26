using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawn : MonoBehaviour {

	// Making an array if more gems will be added to the game for different scores
	public GameObject[] gems;
	// An array for the different gen points for the gem
	public Transform[] spawn;
    float delayTime = 5f;

	// Use this for initialization
	 void Start () {
		// Repeatly call the spawn method
        InvokeRepeating("Spawn", delayTime, 2f);	
	}
	
	void Spawn()
    {
		// Pick a random place to gen the gem
        int spawnIndex = Random.Range(0, spawn.Length);
        int gemsIndex = Random.Range(0, gems.Length);
        Instantiate(gems[gemsIndex], spawn[spawnIndex].position, spawn[spawnIndex].rotation);
	}
}
