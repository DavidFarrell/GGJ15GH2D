using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

	public int timeDecay = -1;
	public int powerTarget = 100;
	public int powerIncrease = 5;
	public int powerDecrease = 10;


	private int power;
	private int failures = 0;

	// Use this for initialization
	void Start () {
	
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

	public bool thresholdCheck(){
		return power > powerTarget;
	}

	void pollInput (){
	}


}
