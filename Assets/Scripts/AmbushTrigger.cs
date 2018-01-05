using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AmbushTrigger : MonoBehaviour {
	public GameObject wolf;
	GameObject Ambusherwolf1;
	GameObject Ambusherwolf2;
	public GameObject goblin;
	GameObject Ambushergoblin1;
	GameObject Ambushergoblin2;
	public GameObject hobgoblin;
	GameObject Ambusherhobgoblin1;
	GameObject Ambusherhobgoblin2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnAmbushers(){

		Ambusherwolf1.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = true;
		Ambusherwolf1.transform.position = transform.GetChild(0).transform.position;

		Ambusherwolf2.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = true;
		Ambusherwolf2.transform.position = transform.GetChild(1).transform.position;

		Ambushergoblin1.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = true;
		Ambushergoblin1.transform.position = transform.GetChild(2).transform.position;

		Ambushergoblin2.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = true;
		Ambushergoblin2.transform.position = transform.GetChild(3).transform.position;

		Ambusherhobgoblin1.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = true;
		Ambusherhobgoblin1.transform.position = transform.GetChild(4).transform.position;

		Ambusherhobgoblin2.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = true;
		Ambusherhobgoblin2.transform.position = transform.GetChild(5).transform.position;

		yield return new WaitForSecondsRealtime(0.2f);
	}

	void OnTriggerEnter(Collider other){
		GetComponent<AudioSource> ().Play ();

		GameObject.Find("Barbarian mage").GetComponent<CharacterScript>().healthPotAmount += 3;

		Ambusherwolf1 = Instantiate (wolf, transform.GetChild(0).transform.position, Quaternion.identity) as GameObject;
		Ambusherwolf2 = Instantiate (wolf, transform.GetChild(1).transform.position, Quaternion.identity) as GameObject;
		Ambushergoblin1 = Instantiate (goblin, transform.GetChild(2).transform.position, Quaternion.identity) as GameObject;
		Ambushergoblin2 = Instantiate (goblin, transform.GetChild(3).transform.position, Quaternion.identity) as GameObject;
		Ambusherhobgoblin1 = Instantiate (hobgoblin, transform.GetChild(4).transform.position, Quaternion.identity) as GameObject;
		Ambusherhobgoblin2 = Instantiate (hobgoblin, transform.GetChild(5).transform.position, Quaternion.identity) as GameObject;
		Ambusherwolf1.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
		Ambusherwolf2.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
		Ambushergoblin1.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
		Ambushergoblin2.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
		Ambusherhobgoblin1.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
		Ambusherhobgoblin2.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;

		StartCoroutine (SpawnAmbushers ());

		GetComponent<LineRenderer> ().enabled = false;
		GetComponent<CapsuleCollider>().enabled = false;
	}
}
