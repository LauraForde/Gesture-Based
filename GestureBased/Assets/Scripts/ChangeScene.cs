using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string GameOver;

    public void Play()
    {
        SceneManager.LoadScene(GameOver);

    }
}
