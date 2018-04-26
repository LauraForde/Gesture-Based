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
    public GameManager manager;
    public GameObject gameOver;
    public GemSpawn gem;

    //Myo variables
    public Material waveInMaterial;
    public Material waveOutMaterial;
    public Material doubleTapMaterial;
    private Pose _lastPose = Pose.Unknown;

    // Use this for initialization
    void Start () {
		// Find the rigid body of the player
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, speed);
    }
	
	// Update is called once per frame
	void Update () {

		// Find the myo
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();


		// If the new pose is not the same as the last pose
		if (thalmicMyo.pose != _lastPose){
			_lastPose = thalmicMyo.pose;

			// If the pose is wave in
			if (thalmicMyo.pose == Pose.WaveIn){
				// Move the car to the left
				myRigidBody.position = new Vector2(myRigidBody.position.x - 10, myRigidBody.position.y );

				// If the car goes off screen
				if (myRigidBody.position.x < -12.6){
					// End the game
					gameOver.gameObject.SetActive(true);
					Destroy(myRigidBody);
				}
				// Call the method so myo does not lock
				ExtendUnlockAndNotifyUserAction(thalmicMyo);
			}

			// If the pose is wave out
			else if (thalmicMyo.pose == Pose.WaveOut){
				// Move the car to the right
				myRigidBody.position = new Vector2( myRigidBody.position.x + 10, myRigidBody.position.y);

				// If the car goes off the screen
				if (myRigidBody.position.x > 12.47){
					// End the game
					gameOver.gameObject.SetActive(true);
					Destroy(myRigidBody);
				}
			}
			// Call the method so myo does not lock
			ExtendUnlockAndNotifyUserAction(thalmicMyo);
		}

	}

	// When the car is triggered
    void OnTriggerEnter2D(Collider2D car){
		// If the trigger object is another car
        if (car.gameObject.tag == "Car"){
			// End the game
			gameOver.gameObject.SetActive (true);
			Destroy(myRigidBody);
        }
    }

	// Don't lock the myo
    void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo){
        ThalmicHub hub = ThalmicHub.instance;
        if (hub.lockingPolicy == LockingPolicy.Standard){
            myo.Unlock(UnlockType.Timed);
        }
        myo.NotifyUserAction();
    }  
}