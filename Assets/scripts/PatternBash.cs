﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/**Logic for the patternbash controls on the face buttons*/
public class PatternBash : Spell {

	public string pattern; /*Pattern string containing letters A,B,X or Y e.g "ABXY"*/
	public GameObject ButtonA;
	public GameObject ButtonB;
	public GameObject ButtonX;
	public GameObject ButtonY;
	public GameObject ButtonsOverlay;

	private Animator AAnimator;
	private Animator BAnimator;
	private Animator XAnimator;
	private Animator YAnimator;

	private int buttonValue; //FaceID variable

	//Mapping of faceIDs to button strings
	protected Dictionary <string, int> faceDict =
	new Dictionary<string, int>() {    
		{"ButtonA", 1},
		{"ButtonB", 2},
		{"ButtonX", 3},
		{"ButtonY", 4}
	};



	protected bool[] oldPresses = new bool[4]; /*ABXY, 1 is pressed 0 is depressed*/
	protected bool[] keyPresses = new bool[4]; 
	private int cursor = 0;
	string currentButton;

	
	// Use this for initialization
	void Start () {
		//Get First Button to highlight
		currentButton = "Button" + pattern[0];
		faceDict.TryGetValue(currentButton,out buttonValue);
		ButtonsOverlay.GetComponent<UI_Glyphs_PressThis>().faceID = buttonValue;

		//Get the animators
		AAnimator = ButtonA.GetComponent<Animator>(); 
		BAnimator = ButtonB.GetComponent<Animator>(); 
		XAnimator = ButtonX.GetComponent<Animator>(); 
		YAnimator = ButtonY.GetComponent<Animator>();

		//Light up the buttons contained in the pattern e.g. BABY will not light up X
		if (pattern.Contains("A")) AAnimator.SetBool("On",true);
		if (pattern.Contains("B")) BAnimator.SetBool("On",true);
		if (pattern.Contains("X")) XAnimator.SetBool("On",true);
		if (pattern.Contains("Y")) YAnimator.SetBool("On",true);

	}
	
	// Update is called once per frame
	void Update () {
		//Reset keypresses and store previous

		oldPresses = copyBool(keyPresses);
		keyPresses = new bool[]{false,false,false,false};

		//TODO: Draw UI element for the current button
		pollInput ();
		
		if (differentButtons() && !buttonsEmpty()) {
			if(multiplePresses()) {
				failPress();
			}
			else if (Input.GetButtonDown(currentButton)) {
				successPress();
			} else failPress();
			currentButton = getNextButton();
			faceDict.TryGetValue(currentButton,out buttonValue);
			ButtonsOverlay.GetComponent<UI_Glyphs_PressThis>().faceID = buttonValue;
		}
 	
		
	}

	/*Fills keyPresses with booleans as to whether or not that button has been pressed
	 Also triggers press animation on press*/
	protected void pollInput() {
		if (Input.GetButtonDown("ButtonA")) {
			keyPresses[0] = true;
			AAnimator.SetTrigger("Pressed");
		}
		if (Input.GetButtonDown("ButtonB")) {
			keyPresses[1] = true;
			BAnimator.SetTrigger("Pressed");
		}
		if (Input.GetButtonDown("ButtonX")) {
			keyPresses[2] = true;
			XAnimator.SetTrigger("Pressed");
		}
		if (Input.GetButtonDown("ButtonY")) {
			keyPresses[3] = true;
			YAnimator.SetTrigger("Pressed");

		}
	}

	/*Gets the next button that a check needs to be made for, and cycles it to the next in the pattern*/
	string getNextButton() {
		if (cursor == pattern.Length) cursor = 0;
		cursor++;
		return "Button" + pattern[cursor-1];
	}

	/*Checks that the face buttons are not pressed*/
	protected bool buttonsEmpty() {
		for(int i = 0; i < 4; i++) {
			if (keyPresses[i]) return false;
		}
		return true;
	}

	//If two keys are pressed the program fails
	protected bool multiplePresses() {
		int multiPress = 0;
		for (int i = 0; i < 4; i++) {
			if (keyPresses[i]) multiPress++;
		}
		if (multiPress > 1) return true;
		return false;
	}

	//Run an XOR check between buttons to determine if the user has made an input
	protected bool differentButtons() {
		for (int i = 0; i < 4; i ++) {
			if (oldPresses[i] ^ keyPresses[i]) return true;
		}
		return false;
	}

	/*When the correct button is pressed in the right order and other buttons aren't
	 pressed this function should be called.*/
	protected void successPress(){
		Debug.Log("Hit!");
		//Increase the player's health-bar or something
	}
	/*multiple presses or wrong presses run this function*/
	protected void failPress() {
		Debug.Log("Fail!");
		//Reduce the player's health or something
	}

	protected bool[] copyBool(bool[] keyPresses) {
		bool[] presses = new bool[keyPresses.Length];
		for (int i = 0; i < keyPresses.Length;i++) {
			presses[i] = keyPresses[i];
		}
		return presses;
	}

}
