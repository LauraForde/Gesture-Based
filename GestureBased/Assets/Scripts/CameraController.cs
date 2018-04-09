using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	/*private Vector3 lastPosition;
	private Transform target;

	void Start () {
		target = GameObject.FindWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
		lastPosition = new Vector3(target.position.x, target.position.y + 10f, target.position.z);
		transform.position = Vector3.Lerp(transform.position, lastPosition, Time.deltaTime * 8);
	}*/

	public PlayerController player;
	private Vector3 lastPosition;
	private float distance;

	void Start(){
		player = FindObjectOfType<PlayerController>();
		lastPosition = player.transform.position;
	}

	void Update(){

		distance = player.transform.position.y - lastPosition.y;
		transform.position = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);

		lastPosition = player.transform.position;
	}
}
