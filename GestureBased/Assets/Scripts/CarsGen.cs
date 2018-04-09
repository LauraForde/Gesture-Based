using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsGen : MonoBehaviour {

	//public GameObject car;
	public ObjectPooler[] cars;
	/*public ObjectPooler carRed;
	public ObjectPooler carYellow;
	public ObjectPooler carGreen;*/
	public Transform genPoint;
	public float distance;
	private int select;
	public float minDistance;
	public float maxDistance;
	private float[] width;
	
	void Start(){
		width = new float[cars.Length];
		for(int i = 0; i < cars.Length; i++){
			width[i] = cars[i].pooledObject.GetComponent<BoxCollider2D>().size.y;
		}
	}

	void Update(){
		if(transform.position.y < genPoint.position.y){
			distance = Random.Range(minDistance, maxDistance);
			select = Random.Range(0, cars.Length);
			//transform.position = new Vector3(transform.position.x, transform.position + width[select] + distance, transform.position.z);
			transform.position = new Vector3 (transform.position.x, transform.position.y + width[select] + distance, transform.position.z);

			GameObject evilCar = cars[select].GetPooledObject();
		
			evilCar.transform.position = transform.position;
			evilCar.transform.rotation = transform.rotation;
		}
	}
}
