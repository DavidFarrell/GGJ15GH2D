﻿using UnityEngine;
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

	private GameObject leftJoySpell;
	private GameObject rightJoySpell;
	private GameObject faceSpell;
	private GameObject triggerSpell;

	private List<string> players;
	// Use this for initialization
	void Start () {
		assignSpells ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void assignSpells(){
		clearSpells ();

		leftJoySpell = joystickSpells [Random.Range (0, joystickSpells.Length )];
		rightJoySpell = joystickSpells [Random.Range (0, joystickSpells.Length )];
		faceSpell = faceSpells [Random.Range (0, faceSpells.Length )];
		triggerSpell = triggerSpells [Random.Range (0, triggerSpells.Length )];


		List<GameObject> spells = new List<GameObject>();
		spells.Add(leftJoySpell);
		spells.Add (rightJoySpell);
		spells.Add(faceSpell);
		spells.Add(triggerSpell);



		players = new List<string> (){
			"Player1_Widget_SpawnPoint", "Player2_Widget_SpawnPoint", "Player3_Widget_SpawnPoint", "Player4_Widget_SpawnPoint"};

		// players should get different spell types each round
		Shuffle (players);


		//spawns all 4 at once for testing, comment out to allow individual spawning
		for (int i = 1; i <= 4; i++)
			spawnPlayerSpell (i);

			

	}

	public void spawnPlayerSpell(int playerNum){
		switch (playerNum) {
			case 1:
			{
				Player1Spell = (GameObject)Instantiate (leftJoySpell);
				GameObject player1 = GameObject.Find (players[0]);
				Player1Spell.transform.parent = player1.transform;
				Player1Spell.transform.localPosition = new Vector3 (0, 0, 0);
				Player1Spell.GetComponent<Spell> ().setLeftJoystick (true);
				Player1Spell.SetActive (true);
			}
			case 2:
			{
				Player2Spell = (GameObject)Instantiate (rightJoySpell);
				GameObject player2 = GameObject.Find (players[1]);
				Player2Spell.transform.parent = player2.transform;
				Player2Spell.transform.localPosition = new Vector3 (0, 0, 0);
				Player2Spell.GetComponent<Spell> ().setLeftJoystick (false);
				Player2Spell.SetActive (true);
			}
			case 3:
			{
				Player3Spell = (GameObject)Instantiate (faceSpell);
				GameObject player3 = GameObject.Find (players[2]);
				Player3Spell.transform.parent = player3.transform;
				Player3Spell.transform.localPosition = new Vector3 (0, 0, 0);
				Player3Spell.SetActive (true);
			}
			case 4:
			{
				Player4Spell = (GameObject)Instantiate (triggerSpell);
				GameObject player4 = GameObject.Find (players[3]);
				Player4Spell.transform.parent = player4.transform;
				Player4Spell.transform.localPosition = new Vector3 (0, 0, 0);
				Player4Spell.SetActive (true);
			}

			
	}
	
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

	void clearSpells(){
		if (Player1Spell != null)
			Destroy (Player1Spell);
		if (Player2Spell != null)
			Destroy (Player2Spell);
		if (Player3Spell != null)
			Destroy (Player3Spell);
		if (Player4Spell != null)
			Destroy (Player4Spell);
	}
	
}
