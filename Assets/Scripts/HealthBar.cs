﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Slider mySlider;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        mySlider.value = GameObject.Find("Barbarian mage").GetComponent<CharacterScript>().health;   
	}
}
