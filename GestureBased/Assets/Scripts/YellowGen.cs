using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGen : MonoBehaviour {

	public GameObject platform;
	public Transform genPoint;
	public float distance;
	private float width;
	public float distanceMin;
	public float distanceMax;
	public ObjectPooler[] objPool;
	private int select;
	private float[] pWidth;
	private float minHeight;
	public Transform max;
	private float maxHeight;
	public float heightChange;
	private float change;

	void Start () {
		//width = platform.GetComponent<BoxCollider2D> ().size.x;

		pWidth = new float[objPool.Length];

		for(int i = 0; i < objPool.Length; i++){
			pWidth [i] = objPool[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = max.position.y;

	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < genPoint.position.y) {

			distance = Random.Range (distanceMin, distanceMax);
			select = Random.Range (0, objPool.Length);

			change = transform.position.x + Random.Range (heightChange, -heightChange);

			if (change > maxHeight) {
				change = maxHeight;
			} else if (change < minHeight) {
				change = minHeight;
			}
			transform.position = new Vector3 (change, + transform.position.y + (pWidth[select] / 2) + distance, transform.position.z);
			//Instantiate (randPlatform[select], transform.position, transform.rotation);

			GameObject newPlat = objPool[select].GetPooledObject();

			newPlat.transform.position = transform.position;
			newPlat.transform.rotation = transform.rotation;
			newPlat.SetActive (true);

			transform.position = new Vector3 (transform.position.x, transform.position.x + (pWidth[select] / 2), transform.position.z);
		}

	}
}
