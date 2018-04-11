using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour {

	public GameObject pooledObject;
	public int pooledAmount = 2;
	List<GameObject> pooledObjects;

	// Use this for initialization
	void Start () {

		pooledObjects = new List<GameObject>();	
		for(int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
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
