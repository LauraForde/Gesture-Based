using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public GameObject destroyPoint;

	// Use this for initialization
	void Start () {

        destroyPoint = GameObject.Find("DestroyPoint");
		
	}
	
	// Update is called once per frame
/*	void Update () {
        if (transform.position.x < destroyPoint.transform.position.x)
        {

            Destroy (gameObject);
            gameObject.SetActive(false);
        }

    }
*/
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.name == "Gem"){
            gameObject.SetActive(false);
        }
    }
}
