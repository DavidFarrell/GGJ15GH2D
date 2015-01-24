using UnityEngine;
using System.Collections;

public class PressureHold : Spell {

	public string triggerChoice; //either "TriggersL" or "TriggersR"

	private float joystickInput;
	public float scaleFactor = 1;

	private PowerBarDual myPowerBarDual;


	// Use this for initialization
	new void Start () {
		time = timeDecaySpeed;
		myPowerBarDual = GetComponent<PowerBarDual>();
		myPowerBarDual.currentMinThreshold = 30;
		myPowerBarDual.currentMaxThreshold = 60;
		myPowerBarDual.currentPower = 0;
	}

	new public float currentPower(){
		return myPowerBarDual.currentPower;
	}

	new protected void modifyPower(float powerChange){
		myPowerBarDual.currentPower += powerChange;
		
	}

	new public bool thresholdCheck(){
		return (myPowerBarDual.currentPower > myPowerBarDual.currentMinThreshold && myPowerBarDual.currentPower < myPowerBarDual.currentMaxThreshold);
	}

	// Update is called once per frame
	new void Update () {
		pollInput();
		timeDecay = scaleFactor * joystickInput;
		decayOverTime();
		Debug.Log (joystickInput);
	}

	new void pollInput() {
		joystickInput = Input.GetAxis (triggerChoice);
	}

	new public void decayOverTime()
	{
		time -= Time.deltaTime;
		if (time < 0) {
			modifyPower (timeDecay);
			time = timeDecaySpeed;
		}
	}
	
}
