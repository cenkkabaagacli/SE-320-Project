﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinScript : MonoBehaviour {
	private NavMeshAgent agent;
	private Animator anim;
	private Vector3 previousPosition;
	public float curSpeed;
	public bool isdamaged = false;
	public bool isdead = false;
	public bool isattacking = false;
	public bool isMoving = false;
    public int attack = 12;
    public int health = 45;
	private bool doNotAttack = false;


	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		anim = GetComponent<Animator>();
	}

	public bool getisattacking(){
		return isattacking;
	}

	public void DealDamage(){
		if ((GameObject.Find ("Barbarian mage").transform.position - transform.position).magnitude < 6) {
			GameObject.Find ("Barbarian mage").GetComponent<CharacterScript> ().TakeDamage (attack);
		}
	}

	public void setisMoving(bool b){
		isMoving = b;
	}

	// Update is called once per frame
	void Update () {
		if (isdead) {
			isattacking = false;
			GetComponent<Rigidbody> ().isKinematic = true;
			agent.enabled = false;
			GetComponent<SphereCollider> ().enabled = false;
		}
		Vector3 curMove = transform.position - previousPosition;
		curSpeed = curMove.magnitude / Time.deltaTime;
		previousPosition = transform.position;

		anim.SetFloat ("Speed", curSpeed);
		anim.SetBool ("isDead", isdead);
		anim.SetBool ("isDamaged", isdamaged);

		if (doNotAttack == false) {
			if (GameObject.Find ("Barbarian mage").GetComponent<Animation> ().IsPlaying ("death") == false) {
				if(isMoving) {
					if ((GameObject.Find ("Barbarian mage").transform.position - transform.position).magnitude > 12) {
						isattacking = false;
						goto skip;
					} 
					if ((transform.position - agent.destination).magnitude < 12) {
						isattacking = true;
					}

					else {
						isattacking = false;
					}
				}

			}
			else {
				isattacking = false;
				doNotAttack = true;
			}
		}
		skip:
		anim.SetBool ("isAttacking", isattacking);
	}

    public void GetAttacked(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            isdead = true;
			GameObject.Find ("Barbarian mage").GetComponent<CharacterScript> ().SetExp(25);

        }
    }
}
