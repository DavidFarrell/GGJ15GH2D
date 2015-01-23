using UnityEngine;
using System.Collections;

/**Logic for the patternbash controls on the face buttons*/
public class PatternBash : MonoBehaviour {

	public string pattern; /*Pattern string containing letters A,B,X or Y e.g "ABXY"*/
	private bool[] oldPresses = new Boolean[4]; /*ABXY, 1 is pressed 0 is depressed*/
	private bool[] keyPresses = new Boolean[4]; 
	private int cursor = 0;
	
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		//Poll for input
		if(Input.getButtonDown("")) {
			;
		}
	}

	void successPress(){
		Debug.log("Hit!");
		//Increase the player's health-bar or something
	}
	void failPress() {
		Debug.log("Fail!");
		//Reduce the player's health or something
	}

}
