using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn: MonoBehaviour {
    public GameObject car;
    public float delayTimer = 0.5f;
    float timer;
    private float nextDrop = 0f;
    private float dropInterval = 10f;
    private float changeInterval = 5f;

   /* void Start (){
        timer = delayTimer;
    }*/

    void Update(){
        if(Time.time >= nextDrop)
        {
            Spawn();
            nextDrop += dropInterval;

            if(Time.time >= changeInterval){
                if(dropInterval > 1f){
                    dropInterval *= 0.5f;
                }
                else{
                    dropInterval = 1f;
                }
            }
        }    
    }

    void Spawn(){
        timer -= Time.deltaTime;

        if(timer <= 0){
            Instantiate(car, transform.position, transform.rotation);
            timer = delayTimer;
        }
    }
}