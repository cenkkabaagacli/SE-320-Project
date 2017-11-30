using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {
	private float speed = 1.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float horMovement = Input.GetAxisRaw ("Horizontal");

		float vertMovement = Input.GetAxisRaw ("Vertical");

		transform.Translate (transform.right * horMovement * Time.deltaTime * speed);
		transform.Translate (transform.forward * vertMovement * Time.deltaTime * speed);
		//transform.Translate (maxHorizontalSpeed * rightSpeed * Time.deltaTime,0,maxVerticalSpeed * upSpeed * Time.deltaTime);

		Vector3 moveDirection = new Vector3 (horMovement, 0, vertMovement);
		if (moveDirection != Vector3.zero) {
			Quaternion newRotation = Quaternion.LookRotation (moveDirection);
			transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 8);
		}
	}
}
