using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{

    public int attack = 20;
    public int skillAttack = 40;
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
    private int layerMask = 8;
    public GameObject hitEffect;
    public AudioClip[] hitAudioSources;
    private bool isNPCHit = false;

    // Use this for initialization
    void Start()
    {
		
    }

    IEnumerator WaitForEndScreen(){
        yield return new WaitForSecondsRealtime (1.19f);
        GameOver.SetActive(true);
        endGameSound.SetActive(true);
        mapSound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead==false){
            DeathCheck();
        }

        //deneme için yazdım, silincek
        if (Input.GetKeyDown(KeyCode.L))
        {
            SetExp(20);
            Debug.Log("exp + 20");
        }

        //can potu kullanma
        if (Input.GetKeyDown(KeyCode.H))
        {	
            if (healthPotAmount > 0) {
                UseHealthPot ();
                Debug.Log ("Used health pot");
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (isNPCHit == true)
            {
                Debug.Log("domat");
            }
        }

    }

    public void SetExp(int myExp)
    {
        exp = exp + myExp;
        if (exp >= expNeed)
        {
            int surplusExp;
            level++;
            levelCounter++;
            Debug.Log("level up");
            GameObject.Find("Pause").GetComponent<GUIPanel>().AttributeButtons(levelCounter);
            surplusExp = exp - 100;
            exp = 0 + surplusExp;
            health = health + 30;
            if (health > 100)
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
        gameObject.GetComponent<PlayerMove>().maxVerticalSpeed += 5;
        levelCounter--;
        GameObject.Find("Pause").GetComponent<GUIPanel>().AttributeButtons(levelCounter);
    }

    public void IncAttack()
    {
        attack += 3;
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
            GetComponent<Animation> ().Play ("death");
            StartCoroutine (WaitForEndScreen ());
            isDead = true;
            
        }
    }

    public void SkillAttack()
    {
        Vector3 center = GameObject.Find("SkillSphereCastAllSource").transform.position;
        float radius = 4f;
		
        /*RaycastHit[] Physics.SphereCastAll(source, radius, new Vector3(0,0,0), 1f, int layerMask = 8, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore); 
        
        RaycastHit2D[] CircleCastAll(source, radius, new Vector2(1,1), 3f, layerMask );*/
		
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
			
            if (hitColliders[i].transform.tag == "Enemy") {

			
                if (hitColliders[i].transform.gameObject.GetComponent<WolfScript>() != null) {
                    hitColliders[i].transform.gameObject.GetComponent<WolfScript> ().GetAttacked (GetComponent<CharacterScript> ().skillAttack);
                    Vector3 hitpos = hitColliders[i].transform.position;
                    hitpos += Vector3.up;
                    Instantiate (hitEffect, hitpos, hitColliders[i].transform.rotation);
                    GetComponent<AudioSource> ().clip = hitAudioSources [Random.Range (0, 5)];
                    GetComponent<AudioSource> ().Play ();
                }
			
                if (hitColliders[i].transform.gameObject.GetComponent<GoblinScript>() != null) {
                    hitColliders[i].transform.gameObject.GetComponent<GoblinScript> ().GetAttacked (GetComponent<CharacterScript> ().skillAttack);
                    Vector3 hitpos = hitColliders[i].transform.position;
                    hitpos += Vector3.up;
                    Instantiate (hitEffect, hitpos, hitColliders[i].transform.rotation);
                    GetComponent<AudioSource> ().clip = hitAudioSources [Random.Range (0, hitAudioSources.Length)];
                    GetComponent<AudioSource> ().Play ();
                }
			
                if (hitColliders[i].transform.gameObject.GetComponent<HobgoblinScript>() != null) {
                    hitColliders[i].transform.gameObject.GetComponent<HobgoblinScript> ().GetAttacked (GetComponent<CharacterScript> ().skillAttack);
                    Vector3 hitpos = hitColliders[i].transform.position;
                    hitpos += Vector3.up;
                    Instantiate (hitEffect, hitpos, hitColliders[i].transform.rotation);
                    GetComponent<AudioSource> ().clip = hitAudioSources [Random.Range (0, hitAudioSources.Length)];
                    GetComponent<AudioSource> ().Play ();
                }
			
                if (hitColliders[i].transform.gameObject.GetComponent<TrollScript>() != null) {
                    hitColliders[i].transform.gameObject.GetComponent<TrollScript> ().GetAttacked (GetComponent<CharacterScript> ().skillAttack);
                    Vector3 hitpos = hitColliders[i].transform.position;
                    hitpos += Vector3.up;
                    Instantiate (hitEffect, hitpos, hitColliders[i].transform.rotation);
                    GetComponent<AudioSource> ().clip = hitAudioSources [Random.Range (0, hitAudioSources.Length)];
                    GetComponent<AudioSource> ().Play ();
                }
            }
			
            i++;
        }
    }

    public void UseHealthPot()
    {
        healthPotAmount--;
        health = 100;
    }
	
    private void OnTriggerEnter(Collider npc)
    {
        if (npc.gameObject.name == "Barbarian shaman")
        {
            Debug.Log("npc - true");

            isNPCHit = true;
        }
    }

    private void OnTriggerExit(Collider npc)
    {
        if (npc.gameObject.name == "Barbarian shaman")
        {
            Debug.Log("npc - false");

            isNPCHit = false;
        }
    }

    public void GoToBossRoom()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
        transform.position= new Vector3(1060,0,110);
        GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = true;
    }

    public void GoBackToStartingMap()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
        transform.position= new Vector3(19,0,9);
        GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = true;
    }
}