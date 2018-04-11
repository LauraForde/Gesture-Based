using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGen : MonoBehaviour {

	public GameObject platform;
	public Transform genPoint;
	public float distance;
	private float width;
	private float distanceMin = 20;
	private float distanceMax = -30;
	public ObjectPooler[] objPool;
	private int select;
	private float[] pWidth;
	private float[] pLength;
	private float minHeight;
	//public Transform max;
	private float maxHeight;
	public float heightChange;
	private float change;
	private Rigidbody2D rigid;

	public GameObject car;
	public float delayTimer = 1f;
    float timer = 10.0f;
    private float nextDrop = 0f;
    private float dropInterval = 5f;
    private float changeInterval = 1f;


	void Start () {
		//width = platform.GetComponent<BoxCollider2D> ().size.x;

		pWidth = new float[objPool.Length];
		rigid = GetComponent<Rigidbody2D>();

		for(int i = 0; i < objPool.Length; i++){
			pWidth [i] = objPool[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			//pWidth [i] = objPool[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

		minHeight = transform.position.x;
	//	maxHeight = max.position.x;

	}

	// Update is called once per frame
	void Update () {

        rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y);
        
		Spawn();
           // rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y);
            if (transform.position.y < genPoint.position.y) {

                distance = Random.Range (distanceMin, distanceMax);
                select = Random.Range (0, objPool.Length);

                change = transform.position.y + Random.Range (-heightChange, heightChange);

                if (change > maxHeight) {
                    change = maxHeight;
                } else if (change < minHeight) {
                    change = minHeight;
                }
                transform.position = new Vector3 (change, transform.position.y + (pWidth[select] / 2) - distance, transform.position.z);
                //Instantiate (randPlatform[select], transform.position, transform.rotation);

                GameObject newPlat = objPool[select].GetPooledObject();

                newPlat.transform.position = transform.position;
                newPlat.transform.rotation = transform.rotation;
                newPlat.SetActive (true);


                transform.position = new Vector3 (Random.Range(-20.0f, 20.0f), transform.position.y + (pWidth[select] / 2), transform.position.z);


        }

        }

		void Spawn(){
        timer -= Time.deltaTime;

        if(timer <= 0.0f){
            Instantiate(car, transform.position, transform.rotation);
           // 
		   transform.position += new Vector3(0.0f, dropInterval * Time.deltaTime, 0.0f);
            timer = delayTimer;

            if(Time.time >= nextDrop)
        {
            //Spawn();
            nextDrop += dropInterval;

            if(Time.time >= changeInterval){
                if(dropInterval > 20f){
                    dropInterval *= 1f;
                }
                else{
                    dropInterval = 5f;
                }
            }
        }  
        }
    }
}
