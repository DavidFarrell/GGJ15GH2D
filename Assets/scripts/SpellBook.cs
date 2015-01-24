using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		GameObject leftJoySpell = joystickSpells [Random.Range (0, joystickSpells.Length )];

//		Player1Spell = (GameObject)Instantiate (leftJoySpell);
//		GameObject player1 = GameObject.Find ("Blue_Wizard");
//		Player1Spell.transform.parent = player1.transform;
//		Player1Spell.GetComponent<Spell> ().setLeftJoystick (true);

		GameObject rightJoySpell = joystickSpells [Random.Range (0, joystickSpells.Length )];
		//leftJoySpell.GetComponent<Spell> ().setLeftJoystick (false);

		GameObject faceSpell = faceSpells [Random.Range (0, faceSpells.Length )];


		GameObject triggerSpell = triggerSpells [Random.Range (0, triggerSpells.Length )];


		List<GameObject> spells = new List<GameObject>();
		spells.Add(leftJoySpell);
		spells.Add (rightJoySpell);
		spells.Add(faceSpell);
		spells.Add(triggerSpell);



		List<string> players = new List<string> (){
			"Red_Wizard", "Blue_Wizard", "Green_Wizard", "Yellow_Wizard"};


		Shuffle (players);


		Player1Spell = (GameObject)Instantiate (leftJoySpell);
		GameObject player1 = GameObject.Find (players[0]);
		Player1Spell.transform.parent = player1.transform;
		Player1Spell.GetComponent<Spell> ().setLeftJoystick (true);

		Player2Spell = (GameObject)Instantiate (rightJoySpell);
		GameObject player2 = GameObject.Find (players[1]);
		Player2Spell.transform.parent = player2.transform;
		Player2Spell.GetComponent<Spell> ().setLeftJoystick (false);

		Player3Spell = (GameObject)Instantiate (faceSpell);
		GameObject player3 = GameObject.Find (players[2]);
		Player3Spell.transform.parent = player3.transform;

		Player4Spell = (GameObject)Instantiate (triggerSpell);
		GameObject player4 = GameObject.Find (players[3]);
		Player4Spell.transform.parent = player4.transform;


	}


	public void Shuffle(IList spellList)  
	{  
		for (int i = 0; i < spellList.Count; i++) {
			string temp = (string)spellList[i];
			int randomIndex = Random.Range(i, spellList.Count);
			spellList[i] = spellList[randomIndex];
			spellList[randomIndex] = temp;
		}
	}
	
}
