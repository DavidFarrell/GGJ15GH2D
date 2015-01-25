using UnityEngine;
using System.Collections;

public class CountdownTimer : MonoBehaviour {

	private PowerBar myPowerBar;
	private int power;
	public float timeLeft = 30f;
	public float initialTime = 30f;
	public float speedFactor = 1f;

	// Use this for initialization
	protected void Start () {
		myPowerBar = GetComponent<PowerBar>();
		//myPowerBar.currentThreshold = ;
		myPowerBar.currentPower = 100;
		timeLeft = initialTime;
		
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= (Time.deltaTime)*speedFactor;
		float percentage = timeLeft / initialTime;
		myPowerBar.currentPower = percentage*100;

		if (timeLeft <= 0) {
			// trigger failure
			Debug.Log("YOU DIE");
		}
	}
}
