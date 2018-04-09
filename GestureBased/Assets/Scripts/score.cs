using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour {

    public float scores;
    public static score sc;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetInt("score", 50);
        int x = PlayerPrefs.GetInt("score");


    }
    public void Save()
    {
 
    }

}



