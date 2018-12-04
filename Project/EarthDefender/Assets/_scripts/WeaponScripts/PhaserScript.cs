using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaserScript : MonoBehaviour {

	//thrust of the weapon
	[SerializeField]
	private float thrust = 30;
	//the colour to be used, red for player, green for enemy
	[SerializeField]
	private Color col = new Color(0,0,0, .02f);
	//determine if the weapon is fired by the enemy or the player
	[SerializeField]
	private bool playerWeapon = true;
	//rigidbody of the weapon
	private Rigidbody rb;


	// Use this for initialization
	void Start () {
		//rigid body
		rb = transform.gameObject.AddComponent<Rigidbody>();
		//create a trail for the weapon
		gameObject.AddComponent<TrailRenderer>();
		//set the material colour
		gameObject.GetComponent<Renderer>().material.color = col;
		//trail
		TrailRenderer trail = gameObject.GetComponent<TrailRenderer>();

		//trails attributes
		trail.widthMultiplier =  .04f;
		trail.material.SetColor("_Color", col);
		trail.material.SetColor("_TintColor", new Color(0,0,0,.02f));
		trail.time = .08f ;
		
		//remove gravity
		rb.useGravity = false;
		
		//determine if the weapon belong to the player
		if(playerWeapon)
			//play the beam sound through the players audio source
			SoundManager.Instance.Play(SoundManager.Instance.beam);
		else
			//play the beam sound through the enemy audio source
			SoundManager.Instance.PlayEnemy(SoundManager.Instance.beam);

	}

	void Update(){
		//destroy the object after a time
		Object.Destroy(gameObject, 2.0f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		//add force to the game object to move it
		rb.AddForce(transform.up *  Time.deltaTime * thrust, ForceMode.Impulse);
	
	}

	void OnCollisionEnter(Collision collision)
    {
		//if the object connects with another object of the same time.
		if(collision.gameObject.name == gameObject.name){
			return;
		}
		//if the object connects with an enemy and is fired by a player
		if(collision.gameObject.name.Contains("Enemy") && playerWeapon){
			//get the enemies health value
			int health = collision.collider.gameObject.GetComponent<EnemyHealth>().health;
			//do damage to the enemy at half the value of the health
			int damage = collision.collider.gameObject.GetComponent<EnemyHealth>().damagePerHitTaken/2;
			//set the health to the new value with the damage
			collision.collider.gameObject.GetComponent<EnemyHealth>().health = health - damage;
			//destroy the weapon 
			Destroy(gameObject);

		}
		if(collision.gameObject.name.Contains("Enemy") && !playerWeapon){
			//if the weapon hits an enemy and is fired by and enemy
			//destroy the object so it cant hurt the player
			Destroy(gameObject);
		}
		if(collision.gameObject.name.Contains("Player") && !playerWeapon){
			//if the object hits a player object and is fired by an enemy
			//destroy the player
			Destroy(gameObject);
			Destroy(collision.gameObject);
		}

    }

}
