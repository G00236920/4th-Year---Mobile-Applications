using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	//Value of the ammount of health each enemy will have
	[SerializeField]
	public int health = 100;
	//Damage that the enemy prefab will take if hit
	[SerializeField]
	public int damagePerHitTaken = 100;
	//how many points to give the player if this enemy is destroyed
	public int pointValue = 0;
	//counter
	private int counter = 10;
	
	void Start(){
		//set the point value to the same as its health
		pointValue = health;
	}
	
	// Update is called once per frame
	void Update () {
		//if the enemy has no health remaining
		if(health <= 0){
			//get the sound manager singleton and play a destroyed sound
			SoundManager.Instance.Play(SoundManager.Instance.destroyed);
			//Score singleton, add the enemies value to the player score.
			ScoreKeeper.Instance.score += pointValue;
			//decrease the number of enemies alive as one less than its current value
			GameRules.Instance.setNoOfEnemiesAlive(GameRules.Instance.getNoOfEnemiesAlive() -1);
			Destroy(gameObject);

		}

	}

    void OnCollisionEnter(Collision collision) {
		//If the collider contains the value player, or of the player weapon types
		if(collision.gameObject.name.Contains("Player") || collision.gameObject.name.Contains("PPhaser")  || collision.gameObject.name.Contains("PTorpedo")){
			//Repeatedly flash, for an interval
			InvokeRepeating("Toggler", 0, .4f);
		}
		//if the collider, is a player ship
		if(collision.gameObject.name.Contains("defiantPlayer(Clone)") || collision.gameObject.name.Contains("enterprise_dPlayer(Clone)")  || collision.gameObject.name.Contains("prometheusPlayer(Clone)")){
			//destroy the player ship
			Destroy(collision.gameObject);
		}
	}

	void Toggler() {
		//if the counter reaches one
		if (--counter == 0) {
			//cancel the flashing
			CancelInvoke("Toggler");
			//reset the counter
			counter = 10;
		}
		
		//Cause the object to flash,
		//by making it active and not active repeatedly
		if(gameObject.activeSelf)
			gameObject.SetActive(false);
		else
			gameObject.SetActive(true);
		
	}

}
