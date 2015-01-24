using UnityEngine;
using System.Collections;


public class ButtonBash : PatternBash {
	
	public string buttonToBash;  //ButtonA,ButtonB,ButtonX,ButtonY

	// Use this for initialization
	void Start () {
	
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
			else if (Input.GetButtonDown(buttonToBash)) {
				successPress();
			} else failPress();
		}
		
		
	}
}

