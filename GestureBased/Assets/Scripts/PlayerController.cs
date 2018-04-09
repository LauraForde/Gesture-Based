﻿using Thalmic.Myo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

   
    public GameObject myo = null;
    public float speed;
    public float force;

    private Rigidbody2D myRigidBody;
    public KeyCode left;
    public KeyCode right;

    public Material waveInMaterial;
    public Material waveOutMaterial;
    public Material doubleTapMaterial;


    private Thalmic.Myo.Quaternion _myoQuaternion = null;
    private Thalmic.Myo.Vector3 _myoAccelerometer = null;
    private Thalmic.Myo.Vector3 _myoGyroscope = null;
   

    private Pose _lastPose = Pose.Unknown;


    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

        //ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
    }
	
	// Update is called once per frame
	void Update () {
        Input.gyro.enabled = false;

        

        myRigidBody.freezeRotation = true;
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);

        if (myRigidBody.position.x < -12.6)
        {
            print("fuck you");
            
        }
        else if(myRigidBody.position.x > 12.47)
        {
            print("fuck yoy right");
        }

       

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
                else if (thalmicMyo.pose == Pose.WaveIn)
                {

                myRigidBody.position = new Vector2(myRigidBody.position.x - 10, 0);

                ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }
                else if (thalmicMyo.pose == Pose.WaveOut)
                {

                myRigidBody.position = new Vector2( myRigidBody.position.x + 10, 0);
                

                ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }
               /* else if (thalmicMyo.pose == Pose.DoubleTap)
                {
                    GetComponent<Renderer>().material = doubleTapMaterial;

                    ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }*/
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





