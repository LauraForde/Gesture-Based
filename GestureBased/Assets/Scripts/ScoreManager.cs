using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	int scoreCount;
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + scoreCount;
	}

	public void ScoreAdd(int score){
		scoreCount += score;
	}
}
