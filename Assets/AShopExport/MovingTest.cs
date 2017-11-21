using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingTest : MonoBehaviour {
	NavMeshAgent agent;
	public GameObject goTerrain;
	// Use this for initialization
	void Start () {
		
	}

	void Awake(){
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Input.GetMouseButton (1)) {
			if (goTerrain.GetComponent<Collider> ().Raycast (ray, out hit, Mathf.Infinity)) {
				agent.destination = hit.point;
				agent.isStopped = false;
			}
		}

	}	
}
