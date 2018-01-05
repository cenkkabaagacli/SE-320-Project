using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int curAnimClip;
    public float maxVerticalSpeed = 7;
    private float maxHorizontalSpeed = 60;
	//private Vector3 currentLocation;
	//private Vector3 previousLocation;
	//public float lookSpeed= 10;
    // Use this for initialization
    void Start()
    {
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

        /*transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (transform.position - previousLocation), Time.fixedDeltaTime * lookSpeed);
		previousLocation = currentLocation;

		currentLocation = transform.position;*/

        if (!gameObject.GetComponent<Animation>().IsPlaying("attack"))
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
	
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Animation>().Play("attack");
        }
       

    }

    void OnTriggerStay(Collider other)
	{
		if (other.GetComponent<UnityEngine.AI.NavMeshAgent>().isActiveAndEnabled) {
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