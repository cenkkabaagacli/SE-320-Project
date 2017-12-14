﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValuesScript : MonoBehaviour {

    public Text attackValue;
    public Text defenceValue;
    public Text movementSpeedValue;

	// Use this for initialization
	void Start ()
    {
        
	}

    // Update is called once per frame
    void Update()
    {
        attackValue.text = "" + GameObject.Find("Barbarian mage").GetComponent<CharacterScript>().attack;
        defenceValue.text = "" + GameObject.Find("Barbarian mage").GetComponent<CharacterScript>().defence;
        movementSpeedValue.text = "" + GameObject.Find("Barbarian mage").GetComponent<PlayerMove>().maxHorizontalSpeed;
    }
}