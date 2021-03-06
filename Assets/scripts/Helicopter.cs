﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Helicopter : Spell {

	public string joystick = "R";
	private bool isLeftStick = false;
	public bool clockwise = true;

	private float XAxis;
	private float YAxis;

	private float XWaggle;
	private float YWaggle;

	private string lastAxis = "Y";
	private float penaltyCutout = 1.0f;



	// Use this for initialization
	new void Start () {
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

		penaltyCutout -= Time.deltaTime;
		if (penaltyCutout < 0 && checkForBadInput ()) {
			modifyFailures(1);
			penaltyCutout = 1.0f;
		}
		//Debug.Log (currentFailures ());
		
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

	bool checkForBadInput(){
		if (lastAxis == "X") {
			if (YAxis == -YWaggle){ // Y axis is same as previous Y Axis
				return true;
			}
		}else if (XAxis == -XWaggle){ // X axis is opposite previous X Axis
			return true;
		}
		return false;
	}

	public override void setLeftJoystick(bool isLeft){
		isLeftStick = isLeft;
		GameObject stickText = transform.FindChild("PowerBar/StickID").gameObject;
		stickText.GetComponent<Text>().text = isLeft ? "LS" : "RS" ;
		}

	// overrides
	void pollInput() {

		if (isLeftStick) {
			XAxis = Input.GetAxis ("L_XAxis");
			YAxis = Input.GetAxis ("L_YAxis");
				}
		else{
			XAxis = Input.GetAxis ("R_XAxis");
			YAxis = Input.GetAxis ("R_YAxis");
		}

		if (XAxis > 0.8f) XAxis = 1;
		if (XAxis < -0.8f) XAxis = -1;

		if (YAxis > 0.8f) YAxis = 1;
		if (YAxis < -0.8f) YAxis = -1;
	}

}
