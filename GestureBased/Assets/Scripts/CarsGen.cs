using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsGen : MonoBehaviour {

   // public ObjectPooler objPool;
   // public float distance;
    //public GameObject car;
    public Transform genPoint;
    private float width;
    public ObjectPooler objPool;
    public float distance;

    public void CarMaker(Vector3 make){
		GameObject car = objPool.GetPooledObject ();
		car.transform.position = make;
		car.SetActive (true);

        GameObject car1 = objPool.GetPooledObject ();
		car1.transform.position = new Vector3(make.x - distance, make.y, make.z);
		car1.SetActive (true);

        GameObject car2 = objPool.GetPooledObject ();
		car2.transform.position = new Vector3(make.x + distance, make.y, make.z);
		car2.SetActive (true);
	}

  /*


    void Start()
    {
        
            width = car.GetComponent<BoxCollider2D>().size.y;

    }

    private void Update()
    {
        if (transform.position.y < genPoint.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + width, transform.position.z);
            //Instantiate (platform, transform.position, transform.rotation);

            GameObject newCar = objPool.GetPooledObject();

            newCar.transform.position = transform.position;
            newCar.transform.rotation = transform.rotation;
            newCar.SetActive(true);
        }
    }
*/

}
