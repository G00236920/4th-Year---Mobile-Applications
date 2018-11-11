using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockSpawner : MonoBehaviour {

	private const string ENEMY_PARENT_NAME = "Enemies";
	private const string SPAWN_METHOD = "Spawn";

	[SerializeField]
	[Header("Number of Points")]
	private Transform[] waypoints;
	[SerializeField]
	private float spawnDelay = .2f;
	[SerializeField]
	private float spawnInterval = 1.3f;
	[SerializeField]
	private float enemyStartSpeed = .2f;
	[SerializeField]

	public GameObject Enemyd5;
	public GameObject Enemyktinga;
	public GameObject EnemyKvek;
	public GameObject EnemyVreedex;
	public GameObject Enemyneghvar;
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

			enemyChoice = Enemyneghvar;
			spawnEnemies(enemyChoice);
		}

	}

	private GameObject randomEnemy(){

		GameObject enemyChoice = Enemyd5;

		switch((int)Random.Range(1f, 5f)){
			case 1:
				enemyChoice = Enemyd5;
			break;
			case 2:
				enemyChoice = Enemyktinga;
			break;
			case 3:
				enemyChoice = EnemyKvek;
			break;
			case 4:
				enemyChoice = EnemyVreedex;
			break;
		}

		return enemyChoice;
	}

	private void spawnEnemies(GameObject enemyChoice){

			GameObject enemy = Instantiate(enemyChoice, enemyParent.transform);

			enemy.transform.position = transform.position;

			var follower = enemy.GetComponent<WaypointFollower>();
			
			follower.Speed = enemyStartSpeed;

			foreach(var waypoint in waypoints){

				follower.AddPointsToFollow(waypoint.position);

			}

			GameRules.Instance.enemiesToSpawn -= 1;
			GameRules.Instance.enemiesAlive += 1;
	}


}
