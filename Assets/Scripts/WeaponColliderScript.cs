using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponColliderScript : MonoBehaviour {
	public GameObject parent;
	public float attackRange;
	public GameObject hitEffect;
	// Use this for initialization
	void Start () {
		attackRange = 3;
	}

	IEnumerator Wait(){
		yield return new WaitForSecondsRealtime (0.500f);

		RaycastHit hit;

		Vector3 fwd = transform.TransformDirection (Vector3.forward);
		float thickness = 2f;
		if (Physics.SphereCast (transform.position,thickness, fwd, out hit, 4) && hit.transform.tag == "Enemy") {

			if (hit.transform.gameObject.GetComponent<WolfScript>() != null) {
				hit.transform.gameObject.GetComponent<WolfScript> ().GetAttacked (parent.GetComponent<CharacterScript> ().attack);
				Vector3 hitpos = hit.transform.position;
				hitpos += Vector3.up;
				Instantiate (hitEffect, hitpos, hit.transform.rotation);
			}
			if (hit.transform.gameObject.GetComponent<GoblinScript>() != null) {
				hit.transform.gameObject.GetComponent<GoblinScript> ().GetAttacked (parent.GetComponent<CharacterScript> ().attack);
				Vector3 hitpos = hit.transform.position;
				hitpos += Vector3.up;
				Instantiate (hitEffect, hitpos, hit.transform.rotation);
			}
			if (hit.transform.gameObject.GetComponent<HobgoblinScript>() != null) {
				hit.transform.gameObject.GetComponent<HobgoblinScript> ().GetAttacked (parent.GetComponent<CharacterScript> ().attack);
				Vector3 hitpos = hit.transform.position;
				hitpos += Vector3.up;
				Instantiate (hitEffect, hitpos, hit.transform.rotation);
			}
			if (hit.transform.gameObject.GetComponent<TrollScript>() != null) {
				hit.transform.gameObject.GetComponent<TrollScript> ().GetAttacked (parent.GetComponent<CharacterScript> ().attack);
				Vector3 hitpos = hit.transform.position;
				hitpos += Vector3.up;
				Instantiate (hitEffect, hitpos, hit.transform.rotation);
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
