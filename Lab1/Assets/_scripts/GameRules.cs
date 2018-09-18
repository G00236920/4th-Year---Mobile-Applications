using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour {

    public GameObject Character;
    public static bool CharacterDestroyed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Character has been destroyed
        if (CharacterDestroyed) {

            //Instantiate a new Character
            Instantiate(Character, new Vector3(0.56f, -1.569f, 0), Quaternion.identity);

            //Reset the Bool that decides if we need to repawn
            CharacterDestroyed = false;
        }

	}
}
