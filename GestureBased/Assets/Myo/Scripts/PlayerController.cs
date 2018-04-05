using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool isDead = false;

    public float speed;
    public float force;

    private Rigidbody2D myRigidBody;
    public KeyCode left;
    public KeyCode right;


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


        if(isDead == false)
        {
            if (Input.GetKey(left))
            {
                myRigidBody.velocity = new Vector2(-myRigidBody.velocity.x, speed);
            }
            else if (Input.GetKey(right))
            {
                myRigidBody.velocity = new Vector2(+myRigidBody.velocity.x, speed);
            }
            else
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.y, speed);
            }


        }
	}
}
