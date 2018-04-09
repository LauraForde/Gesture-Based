using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public PlayerController player;
    private Vector3 lastPosition;
    private float distanceMove;

    void Start(){
        player = FindObjectOfType<PlayerController>();
        lastPosition = player.transform.position;
    }

    void Update(){
        distanceMove = player.transform.position.y - lastPosition.y;
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceMove, transform.position.z);
        lastPosition = player.transform.position;
    }
}