using UnityEngine;
using System.Collections;

public class CastSpell : MonoBehaviour {

	public GameObject player1;

	public GameObject player2;

	public GameObject player3;

	public GameObject player4;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		// if they press the button, they better be rigggghhht!
		if (Input.GetButtonDown ("ButtonMiddle")) {
						checkStatus ();
				}
	}

	private bool checkStatus() {
		if (player1.GetComponentInChildren<Spell> ().thresholdCheck () && player2.GetComponentInChildren<Spell> ().thresholdCheck () && player3.GetComponentInChildren<Spell> ().thresholdCheck () && player4.GetComponentInChildren<Spell> ().thresholdCheck ()) {
			Debug.Log ("YOU GOT IT");
			return true;
		} else {
				Debug.Log ("FAIL!");
			return false;
		}
	}
}
