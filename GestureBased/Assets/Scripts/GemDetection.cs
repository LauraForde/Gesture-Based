using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemDetection : MonoBehaviour {

	// Finding the rigid body of the gem
	private Rigidbody2D myRigidBody;
	// Set score to one, to add one to the score every time
	int score = 1;
	// Call the score manager script
    private ScoreManager sm;

    void Start(){
		// Find the score manager
        sm = FindObjectOfType<ScoreManager>();
    }

	// When gem is triggered
	void OnTriggerEnter2D(Collider2D other){
		// If the tag of the triggering object is player
        if (other.gameObject.tag == "Player")
        {
			// Call the add score method in the script
            sm.ScoreAdd(score);
			// Set the gem to false
            gameObject.SetActive(false);
        }
	}
}
