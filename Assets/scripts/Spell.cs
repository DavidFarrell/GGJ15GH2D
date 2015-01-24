using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

	public int timeDecay = -1;
	public float timeDecaySpeed = 0.5f;
	public int powerTarget = 100;
	public int powerIncrease = 5;
	public int powerDecrease = 10;


	private int power;
	private int failures = 0;
	private float time;

	// Use this for initialization
	void Start () {
		time = timeDecaySpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int currentPower(){
		return power;
	}

	public void modifyPower(int powerChange){
		power += powerChange;
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
		return power > powerTarget;
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
