using UnityEngine;
using System.Collections;

public class Waggle : Spell {
	
	public string axis = "R_XAxis";

	
	private float joystickInput;
	private float lastWaggle = 1.0f;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		pollInput ();
		if (waggleChanged ()) {
			modifyPower (10);
		} else
			modifyPower (decay);
		//	Debug.Log (joystickInput);
		Debug.Log (currentPower());
		
		
	}
	
	
	// overrides
	void pollInput() {
		joystickInput = Input.GetAxis (axis);
	}
	
	public bool waggleChanged(){
		if (joystickInput == -lastWaggle) {
			lastWaggle = joystickInput;
			return true;
		}
		return false;
		
	}
	

}