using UnityEngine;
using System.Collections;

public class Waggle : MonoBehaviour {
	
	public string axis = "R_XAxis";
	public int powerLeak = -1;
	
	private float joystickInput;
	private float lastWaggle = 1.0f;
	private int power = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		pollInput ();
		if (waggleChanged ()) {
			modifyPower (10);
		} else
			modifyPower (powerLeak);
		//	Debug.Log (joystickInput);
		Debug.Log (power);
		
		
	}
	
	

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
	
	public void modifyPower(int powerChange){
		power += powerChange;
	}
}