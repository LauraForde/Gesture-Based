using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColDetection : MonoBehaviour {

	private Rigidbody2D myRigidBody;
    public GameObject gameOver;


	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
            //SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            gameOver.gameObject.SetActive(true);

        }
	}
}
