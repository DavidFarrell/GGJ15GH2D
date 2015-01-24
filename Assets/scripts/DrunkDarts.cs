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

	private Vector2 currentForce;
	private Vector2 targetForce;
	public float maxDrunkenness = 2;
	public float drunkChangeSpeed = 1;
	private float currentHangover = 0;
	public float hangoverDuration = 50;
	 	
	public float drunkBounds = 1.5f;

	// Use this for initialization
	new void Start () {
		base.Start ();

		if (!isLeftStick) {
			horizontalAxis = "R_XAxis";
			verticalAxis = "R_YAxis";
		}

		currentForce = new Vector2 (0, 0);
		updateDrunkVector();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// player movement
		pollInput ();
		horizontalMovement = horizontalMovement / speedDampening;
		verticalMovement = (verticalMovement * -1) / speedDampening;
		myPlayer.transform.Translate (new Vector2 (horizontalMovement,verticalMovement ));

		// being drunk
		updateDrunkVector();
		currentForce = iTween.Vector2Update (currentForce, targetForce, drunkChangeSpeed);
		//myPlayer.rigidbody2D.AddForce (currentForce);

		// bounds
		// too far left
		if ((myTarget.transform.position.x + myPlayer.transform.position.x) < -drunkBounds) {
			myPlayer.transform.position = new Vector2( (myTarget.transform.position.x - drunkBounds) , myPlayer.transform.position.y);
		}
		// too far right
		if ((myPlayer.transform.position.x - myTarget.transform.position.x) > drunkBounds) {
			myPlayer.transform.position = new Vector2( (myTarget.transform.position.x + drunkBounds) , myPlayer.transform.position.y);
		} 
		// too high
		if ( (myPlayer.transform.position.y - myTarget.transform.position.y) > drunkBounds) {
			myPlayer.transform.position = new Vector2( myPlayer.transform.position.x,  (myTarget.transform.position.y + drunkBounds) );
		}
		// too low
		if ( (myPlayer.transform.position.y - myTarget.transform.position.y ) <  -drunkBounds) {
			myPlayer.transform.position = new Vector2( myPlayer.transform.position.x,  (myTarget.transform.position.y - drunkBounds) );
		}

		// scoring
		float distance = Vector2.Distance (myTarget.transform.position, myPlayer.transform.position);
		float scoreImprovement = (scoreDistance - distance) / scoreDampening;
		modifyPower (scoreImprovement);
	}

	private void updateDrunkVector() {
		currentHangover -= Time.deltaTime;
	
		if(currentHangover < 0)
		{
			currentHangover = hangoverDuration;
			
			float x = Random.Range((-maxDrunkenness),maxDrunkenness);
			float y = Random.Range ((-maxDrunkenness), maxDrunkenness);
			targetForce = new Vector2 (x, y);
		}

	}

	// overrides
	void pollInput() {
		horizontalMovement = Input.GetAxis (horizontalAxis);
		verticalMovement = Input.GetAxis (verticalAxis);
	}
}
