using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public Transform roadGen;
	private Vector3 roadStart;
	public PlayerController playerGen;
	private Vector3 playerStart;

	private Destroyer[] destroy;
	// Use this for initialization
	void Start () {
		roadStart = roadGen.position;
		playerStart = playerGen.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		// If the user presses the E key quit the game
		if(Input.GetKeyDown(KeyCode.E)){
			SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
		}
	}
	public void Restart(){
		StartCoroutine ("RestartCo");
	}
	public IEnumerator RestartCo(){
		// Remove the player gen point
		playerGen.gameObject.SetActive(false);
		yield return new WaitForSeconds (0.5f);
        playerGen.transform.position = playerStart;
		roadGen.position = roadStart;
		playerGen.gameObject.SetActive(true);
	}
}
