using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColDetection : MonoBehaviour {

	private Rigidbody2D myRigidBody;

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
		}
	}
}
