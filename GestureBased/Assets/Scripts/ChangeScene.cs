using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class ChangeScene : MonoBehaviour
{
    public string scene;
    public Material waveInMaterial;
    public Material waveOutMaterial;
    public Material doubleTapMaterial;
    PlayerController ps;
    private Pose _lastPose = Pose.Unknown;
    //public GameObject myo = null;

   // ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

    public void Play()
    {
        //SceneManager.LoadScene("move", LoadSceneMode.Single);
    
    
       // DontDestroyOnLoad(this);

        SceneManager.LoadScene("move", LoadSceneMode.Single);


    }
    public void Home()
    {
       
        Application.Quit();
      
    

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
