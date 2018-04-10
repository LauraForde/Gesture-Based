using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsGen : MonoBehaviour {

    public ObjectPooler objPool;
    public float distance;

    /*public void EvilCar(Vector3 ){
		
	}*/
    float carMax = 0.6f; // Maximum height a cloud pair can be set to 
    float carMin = -0.35f; // Minimum height

  
    void Start()
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Player"); 

        
        foreach (GameObject car in cars)
        { 
            Vector3 pos = car.transform.position; //current position
            pos.y = Random.Range(carMin, carMax); // Set the new position to a random range between min / max set above
            car.transform.position = pos; // move the first tile to the new position
        }
    }
  

}
