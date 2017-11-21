using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	public GameObject player;
	int distanceX = 6,distanceY = -12,distanceZ = 6;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (player.transform.position.z - distanceX, player.transform.position.y - distanceY, player.transform.position.y - distanceZ);
	}
	
	// Update is called once per frame


	void Update(){

		transform.position = new Vector3( player.transform.position.z, player.transform.position.y, player.transform.position.y);

	}

}
