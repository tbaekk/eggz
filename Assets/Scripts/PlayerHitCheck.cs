using UnityEngine;
using System.Collections;

public class PlayerHitCheck : MonoBehaviour {

	public uiManager ui;
	private PlayerController player;

	void Start () {
		player = gameObject.GetComponentInParent<PlayerController> ();
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		player.ishit = true;
		ui.gameOverActivated ();
	}
	
	void OnTriggerStay2D (Collider2D col) {
		player.ishit = true;
	}
	
	void OnTriggerExit2D (Collider2D col) {
		player.ishit = true;
	}
}
