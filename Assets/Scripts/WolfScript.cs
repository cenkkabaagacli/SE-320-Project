using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WolfScript : MonoBehaviour {
	private NavMeshAgent agent;
	private Animator anim;
	private Vector3 previousPosition;
	private float curSpeed;
	private bool isdamaged = false;
	private bool isdead = false;
	private bool isattacking = false;
	private bool isMoving = false;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
	}

	public bool getisattacking(){
		return isattacking;
	}

	public void setisMoving(bool b){
		isMoving = b;
	}

	// Update is called once per frame
	void Update () {
		Vector3 curMove = transform.position - previousPosition;
		curSpeed = curMove.magnitude / Time.deltaTime;
		previousPosition = transform.position;

		anim.SetFloat ("Speed", curSpeed);
		anim.SetBool ("isDead", isdead);
		anim.SetBool ("isDamaged", isdamaged);

		if (isMoving) {
			if ((transform.position - agent.destination).magnitude < 12) {
				isattacking = true;
			} else {
				isattacking = false;
			}
		}
			
		anim.SetBool ("isAttacking", isattacking);
	}
}
