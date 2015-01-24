using UnityEngine;
using System.Collections;

public class SpellBook : MonoBehaviour {

	public GameObject Player1Spell;
	public GameObject Player2Spell;
	public GameObject Player3Spell;
	public GameObject Player4Spell;

	//public GameObject[] spells;

	public GameObject[] joystickSpells;
	public GameObject[] faceSpells;
	public GameObject[] triggerSpells;



	// Use this for initialization
	void Start () {
		assignSpells ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void assignSpells(){
		GameObject leftJoySpell = joystickSpells [Random.Range (0, joystickSpells.Length -1)];
		//leftJoySpell.GetComponent<Spell> ().setLeftJoystick (true);

		Player1Spell = (GameObject)Instantiate (leftJoySpell);
		Player1Spell.GetComponent<Spell> ().setLeftJoystick (true);

		GameObject rightJoySpell = joystickSpells [Random.Range (0, joystickSpells.Length -1)];
		//leftJoySpell.GetComponent<Spell> ().setLeftJoystick (false);

		GameObject faceSpell = faceSpells [Random.Range (0, joystickSpells.Length -1)];

		GameObject triggerSpell = triggerSpells [Random.Range (0, joystickSpells.Length -1)];



	}


}
