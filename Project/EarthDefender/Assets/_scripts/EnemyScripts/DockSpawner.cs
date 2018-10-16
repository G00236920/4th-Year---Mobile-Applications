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
	private GameObject enemPrefab;
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

		var enemy = Instantiate(enemPrefab, enemyParent.transform);
		enemy.transform.position = transform.position;

		var follower = enemy.GetComponent<WaypointFollower>();
		follower.Speed = enemyStartSpeed;

		foreach(var waypoint in waypoints){

			follower.AddPointsToFollow(waypoint.position);

		}

	}


}
