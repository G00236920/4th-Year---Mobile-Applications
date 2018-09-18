using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Add RigidBody
        gameObject.AddComponent<Rigidbody>();
        //Add a boxCollider
        CapsuleCollider cc = gameObject.AddComponent(typeof(CapsuleCollider)) as CapsuleCollider;
        //Set gravity on the Object
        GetComponent<Rigidbody>().useGravity = true;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        //Destroy the Bomb
        Destroy(gameObject);

        //If the Bomb hits our Character
        if (collision.gameObject.name == "OurCharacter" || collision.gameObject.name == "OurCharacter(Clone)") {

            //Destroy Our Character and Signal GameRules to Spawn Another
            Destroy(collision.gameObject);
            GameRules.CharacterDestroyed = true;

        }
    }
}
