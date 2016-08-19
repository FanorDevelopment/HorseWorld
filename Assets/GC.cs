using UnityEngine;
using System.Collections;

public class GC : MonoBehaviour {

	public GameObject horse;
	public GameObject player;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 20; i++)
		{
			Vector3 spawnPosition;
			spawnPosition.x = Random.Range(player.transform.position.x -20, player.transform.position.x + 20);
			spawnPosition.y = 1;
			spawnPosition.z = Random.Range(player.transform.position.z -20,player.transform.position.z + 20);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(horse, spawnPosition, spawnRotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
