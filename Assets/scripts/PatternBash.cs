using UnityEngine;
using System.Collections;

/**Logic for the patternbash controls on the face buttons*/
public class PatternBash : Spell {

	public string pattern; /*Pattern string containing letters A,B,X or Y e.g "ABXY"*/
	private bool[] oldPresses = new bool[4]; /*ABXY, 1 is pressed 0 is depressed*/
	private bool[] keyPresses = new bool[4]; 
	private int cursor = 0;
	string currentButton;
	
	// Use this for initialization
	void Start () {
		//TODO: UI element initialise for the first button
	
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
			else if (Input.GetButtonDown(currentButton = getNextButton())) {
				successPress();
			} else failPress();
		}
 	
		
	}

	/*Fills keyPresses with booleans as to whether or not that button has been pressed*/
	//Overrides
	void pollInput() {
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

	/*Gets the next button that a check needs to be made for, and cycles it to the next in the pattern*/
	string getNextButton() {
		if (cursor == pattern.Length) cursor = 0;
		cursor++;

		return "Button" + pattern[cursor-1];
	}

	/*Checks that the face buttons are not pressed*/
	bool buttonsEmpty() {
		for(int i = 0; i < 4; i++) {
			if (keyPresses[i]) return false;
		}
		return true;
	}
	
	//If two keys are pressed the program fails
	bool multiplePresses() {
		int multiPress = 0;
		for (int i = 0; i < 4; i++) {
			if (keyPresses[i]) multiPress++;
		}
		if (multiPress > 1) return true;
		return false;
	}

	//Run an XOR check between buttons to determine if the user has made an input
	bool differentButtons() {
		for (int i = 0; i < 4; i ++) {
			if (oldPresses[i] ^ keyPresses[i]) return true;
		}
		return false;
	}

	/*When the correct button is pressed in the right order and other buttons aren't
	 pressed this function should be called.*/
	void successPress(){
		Debug.Log("Hit!");
		modifyPower(5);
	}
	/*multiple presses or wrong presses run this function*/
	void failPress() {
		Debug.Log("Fail!");
		modifyPower (-10);
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
