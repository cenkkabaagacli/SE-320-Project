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
	public GameObject Win;
	public GameObject endGameSound;
	public GameObject mapSound;
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
		if ((GameObject.Find ("Barbarian mage").transform.position - transform.position).magnitude < 10) {
			GameObject.Find ("Barbarian mage").GetComponent<CharacterScript> ().TakeDamage (attack);
		}
	}
	
	public void setisMoving(bool b){
		isMoving = b;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void GetAttacked(int damage)
	{
		health = health - damage;
		if (health <= 0)
		{
			isdead = true;
			GameObject.Find ("Barbarian mage").GetComponent<CharacterScript> ().SetExp(200);
			Win.SetActive(true);
			endGameSound.SetActive(true);
			mapSound.SetActive(false);	
		}
	}
}
