using UnityEngine;
using System.Collections;

public class horseController : MonoBehaviour {

	Animator a;
	float timer;
	int speed;
	bool run;
	Renderer rend;
	public GameObject h;
	// Use this for initialization
	void Start () {
		a = GetComponent<Animator> ();
		timer = Random.Range (5, 20);
		speed = 1;
		rend = h.GetComponent<SkinnedMeshRenderer> ();
		ColorChoice();
	}
	
	// Update is called once per frame
	void Update () {
		if (run)
			speed = 5;
		else
			speed = 1;
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
		a.SetTrigger ("w");
		timer -= 0.1f;
		if (timer <= 0) {
			if (!run)
				Run ();
			else {
				run = false;
				timer = Random.Range (5, 20);
				a.SetTrigger ("w");

				if(Vector3.Distance(gameObject.transform.position, GameObject.FindWithTag("horse").transform.position)<=0.5f)
					Run();
			}

		}
//		print (run);
		}
			

	void Run()
	{
		a.SetTrigger ("r");
		run = true;
		timer = Random.Range (5, 20);
		int r = Random.Range (-60, 60);
		Vector3 newRotation = new Vector3 (Quaternion.identity.x, r, Quaternion.identity.z);
			
		transform.Rotate (newRotation);
	}

	void ColorChoice()
	{
		int CC = Random.Range(1,4);
			if(CC == 1)
			rend.material.color = Color.gray;
		else if (CC == 2)
			rend.material.color = Color.white;
		else
			rend.material.color = Color.black;
	}
}
