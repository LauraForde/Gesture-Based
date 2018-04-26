using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public GameObject destroyPoint;

	// Use this for initialization
	void Start () {
		// Find the destroy point
        destroyPoint = GameObject.Find("DestroyPoint");
		
	}

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.name == "Gem"){
            gameObject.SetActive(false);
        }
    }
}
