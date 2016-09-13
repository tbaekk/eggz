using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 3;
	public float speed = 2f;
	public bool ishit;
	Vector3 position;

	private Rigidbody2D rb2d;
	private Animator anim;
	private float middle;

	// Use this for initialization
	void Start () {
		position = transform.position;
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
		middle = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Hit", ishit);
		if (!ishit) {
			anim.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x));
		}
		
		position.x = Mathf.Clamp (position.x, -2.9f, 2.9f);
		if (!ishit) {
			TouchMove (middle);
		}
	}

	void TouchMove(float middle) {

		if (Input.touchCount > 0) {

			if (Input.GetTouch (0).position.x < middle && Input.GetTouch(0).phase == TouchPhase.Stationary) {
				MoveLeft ();
			}
			else if (Input.GetTouch (0).position.x > middle && Input.GetTouch(0).phase == TouchPhase.Stationary) {
				MoveRight ();
			}
		} 

		else {
			SetVelocityZero();	
		}
	}

	private void MoveLeft(){
		transform.localScale = new Vector3 (-1, 1, 1);

		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f;

		//Fake friction / Ease the x speed of the Player
		rb2d.velocity = easeVelocity;

		//Moving the Player
		rb2d.AddForce ((Vector2.right * speed) * -4f);
		
		//Limit the Speed of the Player
		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2 (-maxSpeed, rb2d.velocity.y);
		}
	}

	private void MoveRight(){
		transform.localScale = new Vector3 (1, 1, 1);
		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f;
		
		//Fake friction / Ease the x speed of the Player
		rb2d.velocity = easeVelocity;

		//Moving the Player
		rb2d.AddForce ((Vector2.right * speed) * 4f);
		
		//Limit the Speed of the Player
		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2 (maxSpeed, rb2d.velocity.y);
		}
	}

	private void SetVelocityZero(){
		rb2d.velocity = Vector2.zero;
	}
}
