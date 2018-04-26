using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGen : MonoBehaviour {

	public GameObject road;
	public Transform genPoint;
	private float width;
	public ObjectPooler objPool;

	// Use this for initialization
	void Start () {
		// Get the width of the road object
		width = road.GetComponent<BoxCollider2D>().size.y;	
	}
	
	// Update is called once per frame
	void Update () {
		// If the gen point is greater than the postion currently in
		if (transform.position.y < genPoint.position.y) {
			// Set the new position of the road
			transform.position = new Vector3 (transform.position.x, transform.position.y + width, transform.position.z);
			// Get another road object
			GameObject newRoad = objPool.GetPooledObject();
			// Position it in the scene and set it to active
			newRoad.transform.position = transform.position;
			newRoad.transform.rotation = transform.rotation;
			newRoad.SetActive (true);

		}
	}
}
