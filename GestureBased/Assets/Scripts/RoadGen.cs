using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGen : MonoBehaviour {

	public GameObject road;
	public Transform genPoint;
	private float width;
	public ObjectPooler objPool;

	private CarsGen carGen;
	public float randCar;

	// Use this for initialization
	void Start () {
		width = road.GetComponent<BoxCollider2D>().size.y;
		carGen = FindObjectOfType<CarsGen>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y < genPoint.position.y) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + width, transform.position.z);
			//Instantiate (platform, transform.position, transform.rotation);

			GameObject newRoad = objPool.GetPooledObject();

			newRoad.transform.position = transform.position;
			newRoad.transform.rotation = transform.rotation;
			newRoad.SetActive (true);

			if(Random.Range(0f, 50f) < randCar){
				carGen.CarMaker(new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z));
			}
		}
	}
}
