using UnityEngine;
using System.Collections;

public class EggHandler : MonoBehaviour {

	public bool iscollided;
	public bool isdestroy;
	
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Collided", iscollided);
		anim.SetBool ("Destroy", isdestroy);
		
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Egg_Explosion")) {
			Destroy (gameObject.GetComponent<Rigidbody2D>());
			Destroy (gameObject.GetComponent<Collider2D>());
		}
		
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Egg_Destroy")) {
			Destroy (gameObject);
		}
	}

	void FixedUpdate() {

	}
}
