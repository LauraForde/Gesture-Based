using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		if(Input.GetKeyDown(KeyCode.R)){
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
	public void Restart(){
		StartCoroutine ("RestartCo");
	}
	public IEnumerator RestartCo(){
		playerGen.gameObject.SetActive(false);
		yield return new WaitForSeconds (0.5f);

		destroy = FindObjectsOfType<Destroyer> ();
		for(int i = 0; i < destroy.Length; i++){
			destroy [i].gameObject.SetActive (false);
		}

		roadGen.position = roadStart;
		playerGen.gameObject.SetActive(true);
	}
}
