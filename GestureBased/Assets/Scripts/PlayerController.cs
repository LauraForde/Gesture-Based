using Thalmic.Myo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
using System;

public class PlayerController : MonoBehaviour {

    // private bool isDead = false;
    public GameObject myo = null;
    public float speed;
    public float force;

    private Rigidbody2D myRigidBody;
    public KeyCode left;
    public KeyCode right;



    public Material waveInMaterial;
    public Material waveOutMaterial;
    public Material doubleTapMaterial;

    private Pose _lastPose = Pose.Unknown;


    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

        //ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();
    }
	
	// Update is called once per frame
	void Update () {

        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        myRigidBody.velocity = new Vector2(speed, myRigidBody.velocity.y);

        /*if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, force);
        }
        */



      /*  if(isDead == false)
        {
            if (Input.GetKey(left))
            {
                myRigidBody.velocity = new Vector2(-myRigidBody.velocity.x, speed);
            }
            else if (Input.GetKey(right))
            {
                myRigidBody.velocity = new Vector2(+myRigidBody.velocity.x, speed);
            }
            else
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.y, speed);
            }*/

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
                  //  GetComponent<Renderer>().material = waveInMaterial;
                    myRigidBody.velocity = new Vector2(+myRigidBody.transform.position.x, speed);

                ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }
                else if (thalmicMyo.pose == Pose.WaveOut)
                {
                   // GetComponent<Renderer>().material = waveOutMaterial;
                     myRigidBody.velocity = new Vector2(+myRigidBody.velocity.x, speed);
            

                    ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }
                else if (thalmicMyo.pose == Pose.DoubleTap)
                {
                    GetComponent<Renderer>().material = doubleTapMaterial;

                    ExtendUnlockAndNotifyUserAction(thalmicMyo);
                }
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



