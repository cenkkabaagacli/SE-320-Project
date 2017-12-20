using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponColliderScript : MonoBehaviour {
	public GameObject parent;

	// Use this for initialization
	void Start () {

	}

	IEnumerator Wait(){
		yield return new WaitForSecondsRealtime (0.500f);

		RaycastHit hit;

		Vector3 fwd = transform.TransformDirection (Vector3.forward);

		if (Physics.Raycast (transform.position, fwd, out hit, 2) && hit.transform.tag == "Enemy") {

			if (hit.transform.gameObject.GetComponent<WolfScript>() != null) {
				hit.transform.gameObject.GetComponent<WolfScript> ().GetAttacked (parent.GetComponent<CharacterScript> ().attack);
			}
			if (hit.transform.gameObject.GetComponent<GoblinScript>() != null) {
				hit.transform.gameObject.GetComponent<GoblinScript> ().GetAttacked (parent.GetComponent<CharacterScript> ().attack);
			}
			if (hit.transform.gameObject.GetComponent<HobgoblinScript>() != null) {
				hit.transform.gameObject.GetComponent<HobgoblinScript> ().GetAttacked (parent.GetComponent<CharacterScript> ().attack);
			}
			if (hit.transform.gameObject.GetComponent<TrollScript>() != null) {
				hit.transform.gameObject.GetComponent<TrollScript> ().GetAttacked (parent.GetComponent<CharacterScript> ().attack);
			}
		}
	}
	// Update is called once per frame
	void Update () {				
		if (parent.GetComponent<Animation> ().IsPlaying("attack")!=true) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				StartCoroutine (Wait ());
			}
		}
	}


}
