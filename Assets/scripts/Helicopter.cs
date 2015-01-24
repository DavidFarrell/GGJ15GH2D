using UnityEngine;
using System.Collections;

public class Helicopter : Spell {

	public string joystick = "R";
	public bool clockwise = true;

	private float XAxis;
	private float YAxis;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		pollInput ();
	
	}

	// overrides
	void pollInput() {
		XAxis = Input.GetAxis (joystick + "_XAxis");
		YAxis = Input.GetAxis (joystick + "_YAxis");
	}

}
