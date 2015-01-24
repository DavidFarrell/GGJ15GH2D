using UnityEngine;
using System.Collections;

public class DrunkDarts : Spell {
	public bool isLeftStick = true;


	public string horizontalAxis = "L_XAxis";
	public string verticalAxis = "L_YAxis";
	
	private float horizontalMovement;
	private float verticalMovement;



	public GameObject myTarget;
	public GameObject myPlayer;

	
	public float speedDampening = 1;
	public float scoreDampening = 1;
	public float scoreDistance = 1;

	// Use this for initialization
	void Start () {
		base.Start ();

		if (!isLeftStick) {
			horizontalAxis = "R_XAxis";
			verticalAxis = "R_YAxis";
		}


	}
	
	// Update is called once per frame
	void Update () {
		
		// player movement
		pollInput ();
		horizontalMovement = horizontalMovement / speedDampening;
		verticalMovement = (verticalMovement * -1) / speedDampening;
		myPlayer.transform.Translate (new Vector2 (horizontalMovement,verticalMovement ));


		// scoring
		float distance = Vector2.Distance (myTarget.transform.position, myPlayer.transform.position);
		float scoreImprovement = (scoreDistance - distance) / scoreDampening;
		Debug.Log (scoreImprovement);
		modifyPower (scoreImprovement);
			//Vector3.Distance(other.position, transform.position);
	}

	// overrides
	void pollInput() {
		horizontalMovement = Input.GetAxis (horizontalAxis);
		verticalMovement = Input.GetAxis (verticalAxis);
	}
}
