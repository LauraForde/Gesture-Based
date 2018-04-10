using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsGen : MonoBehaviour {

    public ObjectPooler objPool;
    public float distance;

    /*public void EvilCar(Vector3 ){
		
	}*/
    float carMax = 0.6f; 
    float carMin = -0.35f;

  
    void Start()
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Player"); 

        
        foreach (GameObject car in cars)
        { 
            Vector3 pos = car.transform.position; 
            pos.y = Random.Range(carMin, carMax); 
            car.transform.position = pos; 
        }
    }
  

}
