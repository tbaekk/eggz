using UnityEngine;
using System.Collections;

public class EggGenerator : MonoBehaviour {

	public GameObject[] eggs;
	int eggNum;
	public float maxPos;
	public float delayTimer;
	float timer;

	// Use this for initialization
	void Start () {
		maxPos = 3.1f;
		timer = delayTimer;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			Vector3 eggPos = new Vector3 (Random.Range(-maxPos, maxPos), transform.position.y, transform.position.z);
			eggNum = Random.Range(0,5);
			Instantiate (eggs[eggNum], eggPos, transform.rotation);
			timer = delayTimer;
		}
	}
}
