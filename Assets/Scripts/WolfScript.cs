using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WolfScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private Vector3 previousPosition;
	public float curSpeed;
	public bool isdamaged = false;
    public bool isdead = false;
	public bool isattacking = false;
	public bool isMoving = false;
    public int attack = 15;
    public int health = 40;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    public bool getisattacking()
    {
        return isattacking;
    }

    public void setisMoving(bool b)
    {
        isMoving = b;
    }

    // Update is called once per frame
    void Update()
    {
		if (isdead) {
			isattacking = false;
			GetComponent<Rigidbody> ().isKinematic = true;
			agent.enabled = false;
			GetComponent<SphereCollider> ().enabled = false;
		}
        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;

        anim.SetFloat("Speed", curSpeed);
        anim.SetBool("isDead", isdead);
        anim.SetBool("isDamaged", isdamaged);

        if (isMoving)
        {
            if ((transform.position - agent.destination).magnitude < 12)
            {
                isattacking = true;
            }
            else
            {
                isattacking = false;
            }
        }

        anim.SetBool("isAttacking", isattacking);
    }

    public void GetAttacked(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            isdead = true;
        }
    }
}