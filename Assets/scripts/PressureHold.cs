using UnityEngine;
using System.Collections;

public class PressureHold : Spell {

	public string triggerChoice; //either "TriggersL" or "TriggersR"

	private float joystickInput;
	public float scaleFactor = 1;

	private PowerBarDual myPowerBarDual;


	// Use this for initialization
	void Start () {
		time = timeDecaySpeed;
		myPowerBarDual = GetComponent<PowerBarDual>();
		myPowerBarDual.currentMinThreshold = 30;
		myPowerBarDual.currentMaxThreshold = 60;
		myPowerBarDual.currentPower = 0;
	}

	public float currentPower(){
		return myPowerBarDual.currentPower;
	}

	protected void modifyPower(float powerChange){
		myPowerBarDual.currentPower += powerChange;
		
	}

	public bool thresholdCheck(){
		return (myPowerBarDual.currentPower > myPowerBarDual.currentMinThreshold && myPowerBarDual.currentPower < myPowerBarDual.currentMaxThreshold);
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

	public void decayOverTime()
	{
		time -= Time.deltaTime;
		if (time < 0) {
			modifyPower (timeDecay);
			time = timeDecaySpeed;
		}
	}
	
}
