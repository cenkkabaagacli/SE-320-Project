using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {
	
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator anim;
    private Vector3 previousPosition;
    public float curSpeed;
    public bool isdamaged = false;
    public bool isdead = false;
    public bool isattacking = false;
    public bool isMoving = false;
    public int attack = 60;
    public int health = 1000;
    public int expValue = 400;
    private int respawnCounter = 1;
    public GameObject Win;
    public GameObject endGameSound;
    public GameObject mapSound;
    public GameObject EndGame;
    private bool doNotAttack = false;
    private Vector3 startPosition;
	
    // Use this for initialization
    void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        startPosition = this.transform.position;
    }
	
    public bool getisattacking(){
        return isattacking;
    }
	
    public void DealDamage(){
        if ((GameObject.Find ("Barbarian mage").transform.position - transform.position).magnitude < 15) {
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
            RespawnCheck((GameObject.Find ("Barbarian mage").transform.position));
        }
		
        Vector3 curMove = transform.position - previousPosition;
        curSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;

        anim.SetFloat ("Speed", curSpeed);
        anim.SetBool ("isDead", isdead);
        anim.SetBool ("isDamaged", isdamaged);

        if (doNotAttack == false)
        {
            if (GameObject.Find("Barbarian mage").GetComponent<Animation>().IsPlaying("death") == false)
            {
                if (isMoving)
                {
                    if ((GameObject.Find("Barbarian mage").transform.position - transform.position).magnitude > 15)
                    {
                        isattacking = false;
                        goto skip;
                    }

                    if ((transform.position - agent.destination).magnitude < 15)
                    {
                        isattacking = true;
                    }

                    else
                    {
                        isattacking = false;
                    }
                }

            }
            else
            {
                isattacking = false;
                doNotAttack = true;
            }
        }
        
        skip:
        anim.SetBool ("isAttacking", isattacking);

        /*if (Input.GetKeyDown(KeyCode.M))
        {
            GetAttacked(50);
        }*/

    }
	
    public void GetAttacked(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            isdead = true;
            GameObject.Find ("Barbarian mage").GetComponent<CharacterScript> ().SetExp(expValue);
            Win.SetActive(true);
            endGameSound.SetActive(true);
            mapSound.SetActive(false);
            EndGame.SetActive(true);
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
                health += 500;
                attack += 50;
                expValue += 80;
                this.transform.position = startPosition;
            }

            isdead = false;
        } 
    }
}