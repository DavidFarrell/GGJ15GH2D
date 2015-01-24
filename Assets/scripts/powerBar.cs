﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class powerBar : MonoBehaviour {

	public Slider spellPowerBar; // ref for the slider
	public float currentPower;

	public Slider spellThreshold;
	public float currentThreshold;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		spellPowerBar.value = currentPower;
		spellThreshold.value = currentThreshold;

	}
}
