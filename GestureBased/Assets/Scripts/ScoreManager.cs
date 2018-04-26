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
		// Updating the score count and the final score count
		scoreText.text = "Score: " + scoreCount;
		finalScore.text = "You Scored: " + scoreCount;
	}

	public void ScoreAdd(int score){
		// Adding to the score
		scoreCount += score;
	}

}
