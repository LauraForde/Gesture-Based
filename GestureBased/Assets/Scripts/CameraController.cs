using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController player;
	private Vector3 lastPosition;
	private float distance;

	void Start(){
		// Finding the player object and getting it's position
		player = FindObjectOfType<PlayerController>();
		lastPosition = player.transform.position;
		}

	void Update(){
		// Moving the player
		distance = player.transform.position.y - lastPosition.y;
		transform.position = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
		lastPosition = player.transform.position;
	}
}
