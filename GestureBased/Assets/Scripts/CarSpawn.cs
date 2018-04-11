using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn: MonoBehaviour {
    public GameObject car;
    public float delayTimer = 5f;
    float timer = 10.0f;
    private float nextDrop = 0f;
    private float dropInterval = 20f;
    private float changeInterval = 5f;

   /* void Start (){
        timer = delayTimer;
    }*/

    void Update(){
          
    }

    void Spawn(){
        timer -= Time.deltaTime;

        if(timer <= 0.0f){
            Instantiate(car, transform.position, transform.rotation);
           // transform.position += new Vector3(0.0f, dropInterval * Time.deltaTime, 0.0f);
            timer = delayTimer;

            if(Time.time >= nextDrop)
        {
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