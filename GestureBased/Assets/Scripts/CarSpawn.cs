using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn: MonoBehaviour {
    public GameObject car;
    public float delayTimer = 0.5f;
    float timer;

    void Start (){
        timer = delayTimer;
    }

    void OnTriggerEnter2D(){
        timer -= Time.deltaTime;

        if(timer <= 0){
            Instantiate(car, transform.position, transform.rotation);
            timer = delayTimer;
        }
    }
}