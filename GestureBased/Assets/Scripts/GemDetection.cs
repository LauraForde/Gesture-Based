using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemDetection : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	int score = 1;
    private ScoreManager sm;

    void Start(){
        sm = FindObjectOfType<ScoreManager>();
    }

	void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player")
        {
            sm.ScoreAdd(score);
            gameObject.SetActive(false);
        }


	}
}
