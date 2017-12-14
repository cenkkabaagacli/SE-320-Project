using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public float maxVerticalSpeed = 7;
    public float maxHorizontalSpeed = 7;

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



        transform.Translate(maxHorizontalSpeed * rightSpeed * Time.deltaTime, 0, maxVerticalSpeed * upSpeed * Time.deltaTime);
        if (rightSpeed != 0.0f || upSpeed != 0.0f)
        {
            gameObject.GetComponent<Animation>().Play("walk");
        }
        else
        {
            gameObject.GetComponent<Animation>().Play("free");
        }


    }

    void OnTriggerStay(Collider other)
    {

        other.gameObject.GetComponent<NavMeshAgent>().destination = transform.position;

        if (other.gameObject.GetComponent<WolfScript>() != null)
        {
            other.gameObject.GetComponent<WolfScript>().setisMoving(true);
            if (other.gameObject.GetComponent<WolfScript>().getisattacking())
            {
                other.gameObject.transform.LookAt(gameObject.transform);
            }
        }

        if (other.gameObject.GetComponent<GoblinScript>() != null)
        {
            other.gameObject.GetComponent<GoblinScript>().setisMoving(true);
            if (other.gameObject.GetComponent<GoblinScript>().getisattacking())
            {
                other.gameObject.transform.LookAt(gameObject.transform);
            }
        }

        if (other.gameObject.GetComponent<HobgoblinScript>() != null)
        {
            other.gameObject.GetComponent<HobgoblinScript>().setisMoving(true);
            if (other.gameObject.GetComponent<HobgoblinScript>().getisattacking())
            {
                other.gameObject.transform.LookAt(gameObject.transform);
            }
        }

        if (other.gameObject.GetComponent<TrollScript>() != null)
        {
            other.gameObject.GetComponent<TrollScript>().setisMoving(true);
            if (other.gameObject.GetComponent<TrollScript>().getisattacking())
            {
                other.gameObject.transform.LookAt(gameObject.transform);
            }
        }
    }
}
