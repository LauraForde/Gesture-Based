using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawn : MonoBehaviour {

	//private ScoreManager sm;
	public GameObject[] gems;
	public Transform[] spawn;
    float delayTime = 5f;

	// Use this for initialization
	 void Start () {
		//sm = FindObjectOfType<ScoreManager>();
        InvokeRepeating("Spawn", delayTime, 2f);	
	}
	
	void Spawn()
    {
        int spawnIndex = Random.Range(0, spawn.Length);
        int gemsIndex = Random.Range(0, gems.Length);

        Instantiate(gems[gemsIndex], spawn[spawnIndex].position, spawn[spawnIndex].rotation);
	}
}
