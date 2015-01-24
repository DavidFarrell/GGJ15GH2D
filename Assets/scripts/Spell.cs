using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

	public float timeDecay = -1.0f;
	public float timeDecaySpeed = 0.5f;
	//public int powerTarget = 100;
	public float powerIncrease = 5.0f;
	public float powerDecrease = 10.0f;

	private PowerBar myPowerBar;
	private int power;
	private int failures = 0;
	private float time;

	// Use this for initialization
	protected void Start () {
		time = timeDecaySpeed;
		myPowerBar = GetComponent<PowerBar>();
		myPowerBar.currentThreshold = 80;
		myPowerBar.currentPower = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float currentPower(){
		return myPowerBar.currentPower;
	}

	public void modifyPower(float powerChange){
		myPowerBar.currentPower += powerChange;

	}

	public int currentFailures(){
		return failures;
	}
	
	public void modifyFailures(int failureChange){
		failures += failureChange;
	}

	void pollInput (){
	}

	public bool thresholdCheck(){
		return myPowerBar.currentPower > myPowerBar.currentThreshold;
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
