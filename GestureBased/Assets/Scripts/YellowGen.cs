using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGen : MonoBehaviour {

	public GameObject platform;
	public Transform genPoint;
	private float width;
	public ObjectPooler[] objPool;
	private int select;
	private float[] pWidth;
	private float[] pLength;
	private Rigidbody2D rigid;

    public float distance;
	public float distanceMin;
	public float distanceMax;
    private float minHeight;
    private float maxHeight;
	public Transform max;
	public float heightChange;
	private float change;

	public GameObject car;
    public GameObject car2;
	public float delayTimer = 5f;
    float timer = -5.0f;
    private float nextDrop = 5f;
    private float dropInterval = 20f;
    private float changeInterval = 5f;


	void Start () {
		//width = platform.GetComponent<BoxCollider2D> ().size.x

		pWidth = new float[objPool.Length];
		rigid = GetComponent<Rigidbody2D>();

		for(int i = 0; i < objPool.Length; i++){
			pWidth [i] = objPool[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
			//pWidth [i] = objPool[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = max.position.y;

	}

	// Update is called once per frame
	void Update () {

        /*for(int i = 0; i < 2; i++){
            Instantiate(car, new Vector3(0, i*50.0f, 0), transform.rotation);
        }*/

        rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y);
        
		Spawn();
           // rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y);
           if (transform.position.x < genPoint.position.x) {

                distance = Random.Range (distanceMin, distanceMax);
                select = Random.Range (0, objPool.Length);

                change = transform.position.y + Random.Range (heightChange, -heightChange);

                if (change > maxHeight) {
                    change = maxHeight;
                } else if (change < minHeight) {
                    change = minHeight;
                }
                transform.position = new Vector3 (transform.position.x + (pWidth[select] / 2) + distance, change, transform.position.z);
                //Instantiate (randPlatform[select], transform.position, transform.rotation);

                GameObject newPlat = objPool[select].GetPooledObject();

                newPlat.transform.position = transform.position;
                newPlat.transform.rotation = transform.rotation;
                newPlat.SetActive (true);


                transform.position = new Vector3 (transform.position.x/* + (pWidth[select] / 2)*/, transform.position.y + (pWidth[select]/2), transform.position.z);

        }

        }

        void Spawn(){
            timer *= Time.deltaTime;

            if(timer <= 0.0f){
                Instantiate(car, transform.position, transform.rotation);

                Instantiate(car2, transform.position, transform.rotation);
                // 
                transform.position += new Vector3(Random.Range(-10,10), dropInterval * Time.deltaTime, 0.0f);
                timer = delayTimer;

                if(Time.time >= nextDrop){
                    //Spawn();
                    nextDrop += dropInterval;

                    if(Time.time >= changeInterval){
                        if(dropInterval > 20f){
                            dropInterval *= 10f;
                        }
                        else{
                            dropInterval = 20f;
                        }
                    }
                }  
            }
        }
}
