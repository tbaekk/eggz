using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

	public Text scoreText;
	public Text replayText;
	public PlayerController player;

	bool gameOver;
	int score;

	// Use this for initialization
	void Start () {
		gameOver = false;
		score = 0;
		InvokeRepeating ("scoreUpdate", 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score;
		if (replayText.IsActive () && Input.touchCount > 0) {
			Replay ();
		}
	}

	private void scoreUpdate(){
		if (!gameOver) {
			score += 1;
		}
	}

	private void Replay(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void gameOverActivated(){
		if (!gameOver) {
			gameOver = true;
			replayText.gameObject.SetActive (true);
			Destroy (player.gameObject.GetComponent<Rigidbody2D>());
		}
	}
}
