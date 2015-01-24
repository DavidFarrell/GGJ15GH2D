using UnityEngine;

using System.Collections;

public class Waggle : Spell {
	
	public string axis = "R_XAxis";
	public bool isLeftStick;
	private float joystickInput;
	private float lastWaggle = 1.0f;
	private SpriteRenderer[] waggleSprites;

	
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
			waggleSprites = GetComponentsInChildren<SpriteRenderer>();
			foreach (SpriteRenderer sprite in waggleSprites)
			{
				sprite.enabled = !sprite.enabled;
			}
			return true;
		}
		return false;
	}

	public override void setLeftJoystick(bool isLeft) {
			isLeftStick = isLeft;
			axis = isLeftStick ?  "L_XAxis" : "R_Axis:";
	}
		

	
}