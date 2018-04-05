using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float force;

    private Rigidbody2D myRigidBody;


	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {

        myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);

        /*if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, force);
        }
        */
	}
}
