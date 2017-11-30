using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingTest : MonoBehaviour
{
	private int curAnimClip;
    NavMeshAgent agent;
    public GameObject goTerrain;

	private Animation ain;
	public AnimationClip [] clips;
    // Use this for initialization
    void Start()
    {
		AddAnim ();
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        /*if (Input.GetMouseButton(1))
        {
            if (goTerrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                agent.destination = hit.point;
                agent.isStopped = false;
				curAnimClip = 3;
				gameObject.GetComponent<Animation> ().Play (clips [curAnimClip].name);
            }


        }
		if (gameObject.transform.position == agent.destination) {
			curAnimClip = 4;
			gameObject.GetComponent<Animation> ().Play (clips [curAnimClip].name);
		}*/
		float rightSpeed = Input.GetAxis ("Horizontal");

		float upSpeed = Input.GetAxis ("Vertical");

		float maxVerticalSpeed = 5;
		float maxHorizontalSpeed = 5;

		transform.Translate (maxHorizontalSpeed * rightSpeed * Time.deltaTime,0,maxVerticalSpeed * upSpeed * Time.deltaTime);
		if (rightSpeed != 0.0f || upSpeed != 0.0f) {
			curAnimClip = 3;
			gameObject.GetComponent<Animation> ().Play (clips [curAnimClip].name);
		} else {
			curAnimClip = 4;
			gameObject.GetComponent<Animation> ().Play (clips [curAnimClip].name);
		}


    }

	void AddAnim () 
	{
		ain = gameObject.GetComponent<Animation>();
		clips = UnityEditor.AnimationUtility.GetAnimationClips (ain);
	}
}




