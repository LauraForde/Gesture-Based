using Thalmic.Myo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject myo;
    public float speed;
    public CameraController cs;
    private Rigidbody2D myRigidBody;

    public Material waveInMaterial;
    public Material waveOutMaterial;
    public Material doubleTapMaterial;
    public GameObject gameOver;
	public GemSpawn gem;

    private Pose _lastPose = Pose.Unknown;

    public GameManager manager;


    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, speed);

    }
	
	// Update is called once per frame
	void Update () {
      
       
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

   

            if (thalmicMyo.pose != _lastPose)
            {
                _lastPose = thalmicMyo.pose;

                // Vibrate the Myo armband when a fist is made.
                if (thalmicMyo.pose == Pose.Fist)
                {
                    thalmicMyo.Vibrate(VibrationType.Medium);
                
                     ExtendUnlockAndNotifyUserAction(thalmicMyo);

                    // Change material when wave in, wave out or double tap poses are made.
                }

                //Move car to the left
                else if (thalmicMyo.pose == Pose.WaveIn)
                {

             
                      myRigidBody.position = new Vector2(myRigidBody.position.x - 10, myRigidBody.position.y );

                    if (myRigidBody.position.x < -12.6)
                    {
                  //  DestroyObject(myRigidBody.gameObject);
                     gameOver.gameObject.SetActive(true);
					Destroy(myRigidBody);
                  

                }

                     ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }

                //Move car to the right
                else if (thalmicMyo.pose == Pose.WaveOut)
                {

                      myRigidBody.position = new Vector2( myRigidBody.position.x + 10, myRigidBody.position.y);

                if (myRigidBody.position.x > 12.47)
                {
                    // DestroyObject(myRigidBody);
                    gameOver.gameObject.SetActive(true);
					Destroy(myRigidBody);

                }
                    // SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);

                }

                ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }
              
            }


    void OnTriggerEnter2D(Collider2D car)
    {
        if (car.gameObject.tag == "Car")
        {
			gameOver.gameObject.SetActive (true);
			Destroy(myRigidBody);
        }
    }


    void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard)
        {
            myo.Unlock(UnlockType.Timed);
        }

        myo.NotifyUserAction();
    }

  
}





