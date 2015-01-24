using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

	public int decay = -1;
	public int powerTarget = 100;



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

	void pollInput (){
	}


	public void testme()
	{
		Debug.Log ("inherit");
	}
}
