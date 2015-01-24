﻿using UnityEngine;
using System.Collections;

/**Logic for the patternbash controls on the face buttons*/
public class PatternBash : MonoBehaviour {

	public string pattern; /*Pattern string containing letters A,B,X or Y e.g "ABXY"*/
	private bool[] oldPresses = new bool[4]; /*ABXY, 1 is pressed 0 is depressed*/
	private bool[] keyPresses = new bool[4]; 
	private int cursor = 0;
	
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		//Reset keypresses and store previous
		oldPresses = copyBool(keyPresses);
		keyPresses = new bool[]{false,false,false,false};

		//Poll for input

		if (Input.GetButtonDown("ButtonA")) {
			keyPresses[0] = true;
		}
		if (Input.GetButtonDown("ButtonB")) {
			keyPresses[1] = true;
		}
		if (Input.GetButtonDown("ButtonX")) {
			keyPresses[2] = true;
		}
		if (Input.GetButtonDown("ButtonY")) {
			keyPresses[3] = true;
		}
		
	}

	void successPress(){
		Debug.Log("Hit!");
		//Increase the player's health-bar or something
	}
	void failPress() {
		Debug.Log("Fail!");
		//Reduce the player's health or something
	}

	bool[] copyBool(bool[] keyPresses) {
		bool[] presses = new bool[keyPresses.Length];
		for (int i = 0; i < keyPresses.Length;i++) {
			presses[i] = keyPresses[i];
		}
		return presses;
	}

}