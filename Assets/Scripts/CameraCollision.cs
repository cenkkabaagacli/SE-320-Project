using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		RaycastHit hit;
		Ray cameraRay = new Ray(transform.position, Vector3.forward);

		float distance = Vector3.Distance(new Vector3(18.04f, 1.5f, 12.95f), transform.position);
		int layerMask = 8;

		if (Physics.Raycast(cameraRay, out hit, distance, layerMask))
		{
			Debug.Log("Hit!");
		}
	}
}
