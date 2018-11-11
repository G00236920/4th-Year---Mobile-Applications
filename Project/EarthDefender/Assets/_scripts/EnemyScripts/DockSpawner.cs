using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockSpawner : MonoBehaviour {

	private const string ENEMY_PARENT_NAME = "Enemies";
	private const string SPAWN_METHOD = "Spawn";

	[SerializeField]
	private float spawnDelay = .2f;
	[SerializeField]
	private float spawnInterval = 1.3f;
	[SerializeField]
	private float enemyStartSpeed = 1f;
	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;
	public GameObject Enemy4;
	public GameObject Boss;
	private GameObject enemyParent;

	private void Start(){

		if(!enemyParent){
			enemyParent = new GameObject(ENEMY_PARENT_NAME);
		}

		SpawnRepeating();
	
	}

	private void SpawnRepeating(){

		InvokeRepeating(SPAWN_METHOD, spawnDelay, spawnInterval);

	}

	private void Spawn(){

		GameObject enemyChoice = null;
		
		if( (GameRules.Instance.enemiesToSpawn > 0) && (GameRules.Instance.maxEnemies > GameRules.Instance.enemiesAlive) ){
			
			enemyChoice = randomEnemy();
			spawnEnemies(enemyChoice);

		}
		if(GameRules.Instance.enemiesToSpawn == 0){

			enemyChoice = Boss;
			SoundManager.Instance.PlayMusic(SoundManager.Instance.boss);
			spawnEnemies(enemyChoice);
		}

	}

	private GameObject randomEnemy(){

		GameObject enemyChoice = Enemy1;

		switch((int)Random.Range(1f, 5f)){
			case 1:
				enemyChoice = Enemy1;
			break;
			case 2:
				enemyChoice = Enemy2;
			break;
			case 3:
				enemyChoice = Enemy3;
			break;
			case 4:
				enemyChoice = Enemy4;
			break;
		}

		return enemyChoice;
	}

	private void spawnEnemies(GameObject enemyChoice){

			GameObject enemy = Instantiate(enemyChoice, enemyParent.transform);

			enemy.transform.position = transform.position;

			var follower = enemy.GetComponent<WaypointFollower>();
			
			follower.Speed = enemyStartSpeed;

			GameRules.Instance.enemiesToSpawn -= 1;
			GameRules.Instance.enemiesAlive += 1;
	}

}
