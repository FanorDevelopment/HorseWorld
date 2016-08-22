using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody rb;
	public float speed;
	Animator a;
	bool run;
	enum horseState {idle, move};
	horseState currentState;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		a = GetComponent<Animator>();
		currentState = horseState.idle;
		}
	
	// Update is called once per frame
	void Update () {
		
		float mH = Input.GetAxis ("Horizontal");
		float mV = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (0, 0, mV) * speed;
	
		transform.Translate(movement);

		Debug.Log (currentState);

		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D))
			currentState = horseState.move;	
		else
			currentState = horseState.idle;	

		if (currentState == horseState.idle) {
			a.SetTrigger ("i");
		}

		if (currentState == horseState.move) {

			if(Input.GetKey(KeyCode.A))
				transform.Rotate(Vector3.down * Time.deltaTime * 20);
			if(Input.GetKey(KeyCode.D))
				transform.Rotate(Vector3.up * Time.deltaTime * 20);

			if (Input.GetKey (KeyCode.LeftShift)) {
				speed = 0.2f;
				a.SetTrigger ("r");
			} else {
				speed = 0.1f;
				a.SetTrigger("w");
			}
		}
	}
}
