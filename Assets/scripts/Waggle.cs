using UnityEngine;

using System.Collections;

public class Waggle : Spell {
	
	public string axis = "R_XAxis";
	private bool isLR = true;
	public bool isLeftStick;
	private float joystickInput;
	private float lastWaggle = 1.0f;

	
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		
		
		pollInput ();
		if (waggleChanged ()) {
			modifyPower (powerIncrease);
		} 
		decayOverTime ();

	}
	
	
	// overrides
	void pollInput() {
		joystickInput = Input.GetAxis (axis);
		if (joystickInput > 0.8f) joystickInput = 1;
		if (joystickInput < -0.8f) joystickInput = -1;
	}
	
	public bool waggleChanged(){
		if (joystickInput == -lastWaggle) {
			lastWaggle = joystickInput;

			return true;
		}
		return false;
	}

	public override void setLeftJoystick(bool isLeft) {
			isLeftStick = isLeft;
			axis = isLeftStick ?  "L_XAxis" : "R_XAxis";
	}
		

	
}