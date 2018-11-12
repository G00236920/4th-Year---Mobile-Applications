using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	[SerializeField]
	public int health = 100;
	[SerializeField]
	public int damagePerHitTaken = 100;
	public int pointValue = 0;

	private int counter = 10;
	
	void Start(){
		pointValue = health;
	}
	
	// Update is called once per frame
	void Update () {

		if(health <= 0){

			SoundManager.Instance.Play(SoundManager.Instance.destroyed);
			ScoreKeeper.Instance.score += pointValue;
			GameRules.Instance.setNoOfEnemiesAlive(GameRules.Instance.getNoOfEnemiesAlive() -1);
			Destroy(gameObject);

		}

	}

    void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.name.Contains("Player") || collision.gameObject.name.Contains("PPhaser")  || collision.gameObject.name.Contains("PTorpedo")){
			InvokeRepeating("Toggler", 0, .4f);
		}
	}

	void Toggler() {

		if (--counter == 0) {
			CancelInvoke("Toggler");
			counter = 10;
		}

		if(gameObject.activeSelf)
			gameObject.SetActive(false);
		else
			gameObject.SetActive(true);
		
	}

}
