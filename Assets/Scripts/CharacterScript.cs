using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{

    public int attack = 20;
    public int defence = 5;
    public float health = 100f;
    private int exp = 0;
    public int level = 1;
    private int levelCounter = 0;
    private int expNeed = 100;
	public bool isDead = false;
    public int healthPotAmount = 3;
    public GameObject GameOver;
    public GameObject endGameSound;
    public GameObject mapSound;

    // Use this for initialization
    void Start()
    {
		
    }

	IEnumerator WaitForEndScreen(){
		yield return new WaitForSecondsRealtime (1.19f);
		print ("hi");
	}

    // Update is called once per frame
    void Update()
    {
		if(isDead==false){
			DeathCheck();
		}

        //deneme için yazdım, silincek
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetExp(20);
            Debug.Log("exp + 20");
        }

        //can potu kullanma
        if (Input.GetKeyDown(KeyCode.H))
        {
            UseHealthPot();
            Debug.Log("pot has used");
        }

    }

    public void SetExp(int myExp)
    {
        exp = exp + myExp;
        if (exp >= expNeed)
        {
            level++;
            levelCounter++;
            Debug.Log("level up");
            GameObject.Find("Pause").GetComponent<GUIPanel>().AttributeButtons(levelCounter);
            expNeed = expNeed * 2;
            health = 100;
            healthPotAmount++;
        }

    }

    public void TakeDamage(int damage)
    {
        health = health - (damage - defence);
        if (health == 0)
        {
            gameObject.GetComponent<Animation>().Play("death");
        }
    }

    public void IncMovSpeed()
    {        
        gameObject.GetComponent<PlayerMove>().maxVerticalSpeed += 2;
        levelCounter--;
        GameObject.Find("Pause").GetComponent<GUIPanel>().AttributeButtons(levelCounter);
    }

    public void IncAttack()
    {
        attack += 5;
        levelCounter--;
        GameObject.Find("Pause").GetComponent<GUIPanel>().AttributeButtons(levelCounter);
    }

    public void IncDefence()
    {
        defence += 2;
        levelCounter--;
        GameObject.Find("Pause").GetComponent<GUIPanel>().AttributeButtons(levelCounter);
    }

	public void DeathCheck(){
		if (health <= 0) {
			GetComponent<PlayerMove> ().enabled = false;
			GameObject.Find("SphereCastSource").GetComponent<WeaponColliderScript> ().enabled = false;
			GetComponent<Animation> ().Play ("death");
			StartCoroutine (WaitForEndScreen ());
			isDead = true;
            GameOver.SetActive(true);
            endGameSound.SetActive(true);
            mapSound.SetActive(false);
        }
	}

    public void UseHealthPot()
    {
        healthPotAmount--;
        health = 100;
    }

}
