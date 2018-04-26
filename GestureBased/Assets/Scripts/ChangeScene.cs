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
   
    public void Play()
    {
		// Go to the move scene when button Play is clicked
        SceneManager.LoadScene("move", LoadSceneMode.Single);
    }
    public void Quit()
    {
		// Quit the application when Quit button is clicked
        Application.Quit();
    }
}