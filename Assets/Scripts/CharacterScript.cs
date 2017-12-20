using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{

    public int attack = 20;
    public int defence = 5;
    public float health = 100f;
    private int exp = 0;
    private int level = 1;
    private int expNeed = 100;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetExp(int myExp)
    {
        exp = exp + myExp;
        if (exp >= expNeed)
        {
            level++;
            expNeed = expNeed * level;
            health = 100;
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
        gameObject.GetComponent<PlayerMove>().maxHorizontalSpeed += 2;
    }

    public void IncAttack()
    {
        attack += 5;
    }

    public void IncDefence()
    {
        defence += 2;
    }


}
