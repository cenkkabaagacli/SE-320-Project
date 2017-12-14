using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class MovingTest : MonoBehaviour
{
	private int curAnimClip;
    //NavMeshAgent agent;
	//private Animation ain;
	//public AnimationClip [] clips;
    // Use this for initialization
    void Start()
    {
		//AddAnim ();
    }

    void Awake()
    {
        //agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        
		float rightSpeed = Input.GetAxis ("Horizontal");

		float upSpeed = Input.GetAxis ("Vertical");

		float maxVerticalSpeed = 7;
		float maxHorizontalSpeed = 7;

		transform.Translate (maxHorizontalSpeed * rightSpeed * Time.deltaTime,0,maxVerticalSpeed * upSpeed * Time.deltaTime);
		if (rightSpeed != 0.0f || upSpeed != 0.0f) {
			gameObject.GetComponent<Animation> ().Play ("walk");
			//curAnimClip = 3;
			//gameObject.GetComponent<Animation> ().Play (clips [curAnimClip].name);
		} else {
			gameObject.GetComponent<Animation> ().Play ("free");
			//curAnimClip = 4;
			//gameObject.GetComponent<Animation> ().Play (clips [curAnimClip].name);
		}


    }

	/*void AddAnim () 
	{
		ain = gameObject.GetComponent<Animation>();
		clips = UnityEditor.AnimationUtility.GetAnimationClips (ain);
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.GetComponent<NavMeshAgent> () != null) {
			other.gameObject.GetComponent<NavMeshAgent> ().destination = transform.position;

		}
	}*/
	void OnTriggerStay(Collider other){
		
		other.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = transform.position;

		if (other.gameObject.GetComponent<WolfScript> () != null) {
			other.gameObject.GetComponent<WolfScript> ().setisMoving (true);
			if (other.gameObject.GetComponent<WolfScript> ().getisattacking ()) {
				other.gameObject.transform.LookAt (gameObject.transform);
			}
		}

		if (other.gameObject.GetComponent<GoblinScript> () != null) {
			other.gameObject.GetComponent<GoblinScript> ().setisMoving (true);
			if (other.gameObject.GetComponent<GoblinScript> ().getisattacking ()) {
				other.gameObject.transform.LookAt (gameObject.transform);
			}
		}

		if (other.gameObject.GetComponent<HobgoblinScript> () != null) {
			other.gameObject.GetComponent<HobgoblinScript> ().setisMoving (true);
			if (other.gameObject.GetComponent<HobgoblinScript> ().getisattacking ()) {
				other.gameObject.transform.LookAt (gameObject.transform);			}
		}

		if (other.gameObject.GetComponent<TrollScript> () != null) {
			other.gameObject.GetComponent<TrollScript> ().setisMoving (true);
			if (other.gameObject.GetComponent<TrollScript> ().getisattacking ()) {
				other.gameObject.transform.LookAt (gameObject.transform);
			}
		}
	}
}




