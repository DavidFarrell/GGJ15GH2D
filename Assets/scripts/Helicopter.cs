using UnityEngine;
using System.Collections;

public class Helicopter : Spell {

	public string joystick = "R";
	public bool clockwise = true;

	private float XAxis;
	private float YAxis;

	private float XWaggle;
	private float YWaggle;

	private string lastAxis = "Y";


	// Use this for initialization
	void Start () {
		base.Start ();
		if (clockwise){
			YWaggle = 1.0f;
			XWaggle = -1.0f;
		}
		if (!clockwise){
			YWaggle = -1.0f;
			XWaggle = 1.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {

		pollInput ();

		
		// 1x -1y -1x 1y
		// 1x 1y -1x -1y
		if (checkForNextInput()) {
			modifyPower(powerIncrease);
		}
		decayOverTime ();
		Debug.Log (currentPower ());
		
	}

	bool checkForNextInput(){
		if (lastAxis == "X") {
			if (YAxis == -YWaggle){ // Y axis is opposite previous Y Axis
				lastAxis = "Y";
				YWaggle = YAxis;
				return true;
			}
		}else if (XAxis == -XWaggle){ // X axis is opposite previous X Axis
			lastAxis = "X";
			XWaggle = XAxis;
			return true;
		}




		return false;
	}

	// overrides
	void pollInput() {
		XAxis = Input.GetAxis (joystick + "_XAxis");
		YAxis = Input.GetAxis (joystick + "_YAxis");
	}

}
