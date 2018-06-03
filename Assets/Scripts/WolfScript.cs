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
	public int attack = 10;
    public int health = 50;
	public int expValue = 20;
	private bool doNotAttack = false;
	private int respawnCounter = 1;
	private Vector3 startPosition;


    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
	    startPosition = this.transform.position;
    }
	void DealDamage(){
		if ((GameObject.Find ("Barbarian mage").transform.position - transform.position).magnitude < 7) {
			GameObject.Find ("Barbarian mage").GetComponent<CharacterScript> ().TakeDamage (attack);
        }
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
			RespawnCheck((GameObject.Find ("Barbarian mage").transform.position));
		}
        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;

        anim.SetFloat("Speed", curSpeed);
        anim.SetBool("isDead", isdead);
        anim.SetBool("isDamaged", isdamaged);

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
        anim.SetBool("isAttacking", isattacking);
    }

    public void GetAttacked(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            isdead = true;
			GameObject.Find ("Barbarian mage").GetComponent<CharacterScript> ().SetExp(expValue);
	        
	        if (GameObject.Find("Barbarian shaman").GetComponent<QuestScript>().WolfQuest == true && 
	            GameObject.Find("Barbarian shaman").GetComponent<QuestScript>().WolfCounter < 13)
	        {
		        GameObject.Find("Barbarian shaman").GetComponent<QuestScript>().WolfCounter++;
	        }
        }
    }
	private void RespawnCheck(Vector3 target)
	{
		if ((target - transform.position).magnitude > 300) {
			isattacking = true;
			GetComponent<Rigidbody> ().isKinematic = false;
			agent.enabled = true;
			GetComponent<SphereCollider> ().enabled = true;
			respawnCounter++;
			health = 0;
			
			for (int i = 1; i <= respawnCounter; i++)
			{
				health += 50;
				attack += 10;
				expValue += 20;
				this.transform.position = startPosition;
			}
			isdead = false;
		} 
	}
}