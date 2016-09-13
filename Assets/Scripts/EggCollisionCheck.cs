using UnityEngine;
using System.Collections;

public class EggCollisionCheck : MonoBehaviour {

	private EggHandler egg;

	void Start () {
		egg = gameObject.GetComponentInParent<EggHandler> ();
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		egg.iscollided = true;
	}
	
	void OnTriggerStay2D (Collider2D col) {
		egg.iscollided = true;
	}
	
	void OnTriggerExit2D (Collider2D col) {
		egg.isdestroy = true;
	}

}
