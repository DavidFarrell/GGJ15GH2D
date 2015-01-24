using UnityEngine;

using System.Collections;

public class Waggle : Spell {
	
	public string axis = "R_XAxis";


	
	private float joystickInput;
	private float lastWaggle = 1.0f;
	private SpriteRenderer[] waggleSprites;

	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		
		pollInput ();
		if (waggleChanged ()) {
			modifyPower (powerIncrease);
		} 
		decayOverTime ();
		Debug.Log (currentPower());

		
		
	}
	
	
	// overrides
	void pollInput() {
		joystickInput = Input.GetAxis (axis);
	}
	
	public bool waggleChanged(){
		if (joystickInput == -lastWaggle) {
			lastWaggle = joystickInput;
			waggleSprites = GetComponentsInChildren<SpriteRenderer>();
			foreach (SpriteRenderer sprite in waggleSprites)
			{
				sprite.enabled = !sprite.enabled;
			}
			return true;
		}
		return false;
		
	}
	

}