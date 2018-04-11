using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour {

	public GameObject pooledObject;
	public int pooledAmount = 2;
	List<GameObject> pooledObjects;

	// Use this for initialization
	 void Start () {

        // Populating the list of pooledObjects
		pooledObjects = new List<GameObject>();	

        // While i is less than the pooledAmount
		for(int i = 0; i < pooledAmount; i++)
        {
            // Make a new game object of that pooled object
            GameObject obj = (GameObject)Instantiate(pooledObject);
            // Don't have it showing on screen
            obj.SetActive(false);

            pooledObjects.Add(obj);
        }	
	}
	
	public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i] == null)
            {
                GameObject obj = (GameObject)Instantiate(pooledObject);
                obj.SetActive(false);
                pooledObjects[i] = obj;
                return pooledObjects[i];
            }

            if(!pooledObjects[i].activeInHierarchy){
                return pooledObjects[i];
            }
        }

                return null;
    }
}
