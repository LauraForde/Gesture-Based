using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float speed;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, speed); 
	}
	
	// Update is called once per frame
	void Update () {

        rb2d.velocity = new Vector2(0, -speed);
		
	}
}
