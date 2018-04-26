using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour {

	// Getting an array of car objects from the prefabs
	public GameObject[] cars;
	// Getting an array of positions from gen points
	public Transform[] spawn;
    float delayTime = 5f;

	// Use this for initialization
	 void Start () {
		// Repeat the Spawn funtion
        InvokeRepeating("Spawn", delayTime, 3f);	
	}
	
	void Spawn()
    {
		// Choose a random gen point from the array
        int spawnIndex = Random.Range(0, spawn.Length);
		// Choose a random car in the prefabs from the array
        int carsIndex = Random.Range(0, cars.Length);
		// Place the car in the random place
        Instantiate(cars[carsIndex], spawn[spawnIndex].position, spawn[spawnIndex].rotation);
    }
}
