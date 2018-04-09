using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObjPooler : MonoBehaviour {

	public GameObject carBlue;
	/*public GameObject carRed;
	public GameObject carGreen;
	public GameObject carYellow;*/

	public int pooledAmount;

	/*List<GameObject> blue;
	List<GameObject> red;
	List<GameObject> green;
	List<GameObject> yellow;*/
	List<GameObject> pooledObjects;

	// Use this for initialization
	void Start () {
	/*	blue = new List<GameObject>();
		red = new List<GameObject>();
		green = new List<GameObject>();
		yellow = new List<GameObject>(); */

		for(int i = 0; i < pooledAmount; i++){
			GameObject objBlue = (GameObject)Instantiate(carBlue);
		/*	GameObject objRed = (GameObject)Instantiate(carRed);
			GameObject objGreen = (GameObject)Instantiate(carGreen);
			GameObject objYellow = (GameObject)Instantiate(carYellow);	*/	
		
			objBlue.SetActive(false);
		/*	objRed.SetActive(false);
			objGreen.SetActive(false);
			objYellow.SetActive(false);*/

			pooledObjects.Add(objBlue);
		/*	pooledObjects.Add(objRed);
			pooledObjects.Add(objGreen);
			pooledObjects.Add(objYellow);*/
		}
		
	}

	public GameObject GetPooledObject(){

		for(int i = 0; i < pooledObjects.Count; i++){
			if(!pooledObjects[i].activeInHierarchy){
				return pooledObjects[i];
			}
		}

		GameObject objBlue = (GameObject)Instantiate(carBlue);
		/*GameObject objRed = (GameObject)Instantiate(carRed);
		GameObject objGreen = (GameObject)Instantiate(carGreen);
		GameObject objYellow = (GameObject)Instantiate(carYellow);	*/	
	
		objBlue.SetActive(false);
		/*objRed.SetActive(false);
		objGreen.SetActive(false);
		objYellow.SetActive(false);*/

		return objBlue;
	}
}