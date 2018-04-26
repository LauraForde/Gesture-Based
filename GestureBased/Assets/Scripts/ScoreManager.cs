using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text finalScore;
	int scoreCount;
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + scoreCount;
		finalScore.text = "You Scored: " + scoreCount;
	}

	public void ScoreAdd(int score){
		scoreCount += score;
	}

}
