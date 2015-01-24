using UnityEngine;
using System.Collections;

public class PressureHold : Spell {

	public string triggerChoice; //either "TriggersL" or "TriggersR"
	float joystickInput;
	public float scaleFactor = 1;

	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		pollInput();
		timeDecay = scaleFactor * joystickInput;
		decayOverTime();
		Debug.Log (joystickInput);
	}

	void pollInput() {
		joystickInput = Input.GetAxis (triggerChoice);
	}
	
}
