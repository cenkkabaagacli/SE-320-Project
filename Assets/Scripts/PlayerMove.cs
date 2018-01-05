using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int curAnimClip;
    public float maxVerticalSpeed = 7;
    private float maxHorizontalSpeed = 60;
	private float attackRange;
	public GameObject hitEffect;
	public AudioClip[] hitAudioSources;

	//private Vector3 currentLocation;
	//private Vector3 previousLocation;
	//public float lookSpeed= 10;
    // Use this for initialization
    void Start()
    {
		attackRange = 6;
		gameObject.GetComponent<Animation> ().Play ("free");
    }



    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float rightSpeed = Input.GetAxis("Horizontal");

        float upSpeed = Input.GetAxis("Vertical");

        transform.Translate(0, 0, maxVerticalSpeed * upSpeed * Time.deltaTime);
        transform.Rotate(0, maxHorizontalSpeed * rightSpeed * Time.deltaTime, 0);

		if (!gameObject.GetComponent<Animation>().IsPlaying("attack") && !gameObject.GetComponent<Animation>().IsPlaying("skill"))
        {
            if (rightSpeed != 0.0f || upSpeed != 0.0f)
            {
                gameObject.GetComponent<Animation>().Play("walk");
            }
            else
            {
                gameObject.GetComponent<Animation>().Play("free");
            }
        }
	
		if (Input.GetKeyDown (KeyCode.Space)) {
			gameObject.GetComponent<Animation> ().Play ("attack");
		}
    }

    void OnTriggerStay(Collider other)
	{
		if (other.GetComponent<UnityEngine.AI.NavMeshAgent> () != null) {
			if (other.GetComponent<UnityEngine.AI.NavMeshAgent> ().isActiveAndEnabled) {
				other.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent> ().destination = transform.position;

				if (other.gameObject.GetComponent<WolfScript> () != null) {
					other.gameObject.GetComponent<WolfScript> ().setisMoving (true);
					if (other.gameObject.GetComponent<WolfScript> ().getisattacking ()) {
						if (other.gameObject.GetComponent<WolfScript> ().isdead == false) {
							other.gameObject.transform.LookAt (gameObject.transform);
						}
					}
				}

				if (other.gameObject.GetComponent<GoblinScript> () != null) {
					other.gameObject.GetComponent<GoblinScript> ().setisMoving (true);
					if (other.gameObject.GetComponent<GoblinScript> ().getisattacking ()) {
						if (other.gameObject.GetComponent<GoblinScript> ().isdead) {
							other.gameObject.transform.LookAt (gameObject.transform);
						}            
					}
				}

				if (other.gameObject.GetComponent<HobgoblinScript> () != null) {
					other.gameObject.GetComponent<HobgoblinScript> ().setisMoving (true);
					if (other.gameObject.GetComponent<HobgoblinScript> ().getisattacking ()) {
						if (other.gameObject.GetComponent<HobgoblinScript> ().isdead) {
							other.gameObject.transform.LookAt (gameObject.transform);
						}  
					}
				}

				if (other.gameObject.GetComponent<TrollScript> () != null) {
					other.gameObject.GetComponent<TrollScript> ().setisMoving (true);
					if (other.gameObject.GetComponent<TrollScript> ().getisattacking ()) {
						if (other.gameObject.GetComponent<TrollScript> ().isdead) {
							other.gameObject.transform.LookAt (gameObject.transform);
						}  
					}
				}
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<UnityEngine.AI.NavMeshAgent> () != null) {
			if (other.GetComponent<UnityEngine.AI.NavMeshAgent> ().isActiveAndEnabled) {
				other.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent> ().destination = transform.position;

				if (other.gameObject.GetComponent<WolfScript> () != null) {
					other.gameObject.GetComponent<WolfScript> ().setisMoving (true);
					if (other.gameObject.GetComponent<WolfScript> ().getisattacking ()) {
						if (other.gameObject.GetComponent<WolfScript> ().isdead == false) {
							other.gameObject.transform.LookAt (gameObject.transform);
						}
					}
				}

				if (other.gameObject.GetComponent<GoblinScript> () != null) {
					other.gameObject.GetComponent<GoblinScript> ().setisMoving (true);
					if (other.gameObject.GetComponent<GoblinScript> ().getisattacking ()) {
						if (other.gameObject.GetComponent<GoblinScript> ().isdead) {
							other.gameObject.transform.LookAt (gameObject.transform);
						}            
					}
				}

				if (other.gameObject.GetComponent<HobgoblinScript> () != null) {
					other.gameObject.GetComponent<HobgoblinScript> ().setisMoving (true);
					if (other.gameObject.GetComponent<HobgoblinScript> ().getisattacking ()) {
						if (other.gameObject.GetComponent<HobgoblinScript> ().isdead) {
							other.gameObject.transform.LookAt (gameObject.transform);
						}  
					}
				}

				if (other.gameObject.GetComponent<TrollScript> () != null) {
					other.gameObject.GetComponent<TrollScript> ().setisMoving (true);
					if (other.gameObject.GetComponent<TrollScript> ().getisattacking ()) {
						if (other.gameObject.GetComponent<TrollScript> ().isdead) {
							other.gameObject.transform.LookAt (gameObject.transform);
						}  
					}
				}
			}
		}
	}

	void CheckEnemyInFront(){
		RaycastHit hit;

		Vector3 fwd = GameObject.Find("SphereCastSource").transform.TransformDirection (Vector3.forward);
		float thickness = 2f;
		if (Physics.SphereCast (GameObject.Find("SphereCastSource").transform.position,thickness, fwd, out hit, attackRange) && hit.transform.tag == "Enemy") {

			if (hit.transform.gameObject.GetComponent<WolfScript>() != null) {
				hit.transform.gameObject.GetComponent<WolfScript> ().GetAttacked (GetComponent<CharacterScript> ().attack);
				Vector3 hitpos = hit.transform.position;
				hitpos += Vector3.up;
				Instantiate (hitEffect, hitpos, hit.transform.rotation);
				GetComponent<AudioSource> ().clip = hitAudioSources [Random.Range (0, hitAudioSources.Length)];
				GetComponent<AudioSource> ().Play ();
			}
			if (hit.transform.gameObject.GetComponent<GoblinScript>() != null) {
				hit.transform.gameObject.GetComponent<GoblinScript> ().GetAttacked (GetComponent<CharacterScript> ().attack);
				Vector3 hitpos = hit.transform.position;
				hitpos += Vector3.up;
				Instantiate (hitEffect, hitpos, hit.transform.rotation);
				GetComponent<AudioSource> ().clip = hitAudioSources [Random.Range (0, hitAudioSources.Length)];
				GetComponent<AudioSource> ().Play ();
			}
			if (hit.transform.gameObject.GetComponent<HobgoblinScript>() != null) {
				hit.transform.gameObject.GetComponent<HobgoblinScript> ().GetAttacked (GetComponent<CharacterScript> ().attack);
				Vector3 hitpos = hit.transform.position;
				hitpos += Vector3.up;
				Instantiate (hitEffect, hitpos, hit.transform.rotation);
				GetComponent<AudioSource> ().clip = hitAudioSources [Random.Range (0, hitAudioSources.Length)];
				GetComponent<AudioSource> ().Play ();
			}
			if (hit.transform.gameObject.GetComponent<TrollScript>() != null) {
				hit.transform.gameObject.GetComponent<TrollScript> ().GetAttacked (GetComponent<CharacterScript> ().attack);
				Vector3 hitpos = hit.transform.position;
				hitpos += Vector3.up;
				Instantiate (hitEffect, hitpos, hit.transform.rotation);
				GetComponent<AudioSource> ().clip = hitAudioSources [Random.Range (0, hitAudioSources.Length)];
				GetComponent<AudioSource> ().Play ();
			}
		}
	}
		

}