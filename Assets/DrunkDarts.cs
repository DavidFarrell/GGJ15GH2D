using UnityEngine;
using System.Collections;

public class DrunkDarts : MonoBehaviour {
	public bool isLeftStick = true;


	public string horizontalAxis = "L_XAxis";
	public string verticalAxis = "L_YAxis";

	private float horizontalMovement;
	private float verticalMovement;



	// Use this for initialization
	void Start () {
		if (!isLeftStick) {
			horizontalAxis = "R_XAxis";
			verticalAxis = "R_YAxis";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		pollInput ();
		Debug.Log ("Horizontal: " + horizontalMovement + " : Vertical: " + verticalMovement);



	}

	// overrides
	void pollInput() {
		horizontalMovement = Input.GetAxis (horizontalAxis);
		verticalMovement = Input.GetAxis (verticalAxis);
	}
}
