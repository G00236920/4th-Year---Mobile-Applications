using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	[SerializeField]
	public int health = 100;
	[SerializeField]
	public int damagePerHitTaken = 100;
	public int pointValue = 0;
	
	void Start(){
		pointValue = health;
	}
	
	// Update is called once per frame
	void Update () {

		if(health <= 0){

			SoundManager.Instance.Play(SoundManager.Instance.destroyed);
			ScoreKeeper.Instance.score += pointValue;
			GameRules.Instance.enemiesAlive--;
			Destroy(gameObject);

		}

	}



}
