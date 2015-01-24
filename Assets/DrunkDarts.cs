using UnityEngine;
using System.Collections;

public class DrunkDarts : MonoBehaviour {
	public bool isLeftStick = true;


	public string horizontalAxis = "L_XAxis";
	public string verticalAxis = "L_YAxis";
	
	private float horizontalMovement;
	private float verticalMovement;

	private PowerBar myPowerBar;

	public GameObject myTarget;
	public GameObject myPlayer;

	
	public float speedDampening = 1;
	public float scoreDampening = 1;

	// Use this for initialization
	void Start () {
		if (!isLeftStick) {
			horizontalAxis = "R_XAxis";
			verticalAxis = "R_YAxis";
		}

		myPowerBar = GetComponent<PowerBar>();
		myPowerBar.currentThreshold = 80;
		myPowerBar.currentPower = 0;

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
		float scoreImprovement = (1 - distance) / scoreDampening;
		Debug.Log (scoreImprovement);
		myPowerBar.currentPower += scoreImprovement;

			//Vector3.Distance(other.position, transform.position);
	}

	// overrides
	void pollInput() {
		horizontalMovement = Input.GetAxis (horizontalAxis);
		verticalMovement = Input.GetAxis (verticalAxis);
	}
}
