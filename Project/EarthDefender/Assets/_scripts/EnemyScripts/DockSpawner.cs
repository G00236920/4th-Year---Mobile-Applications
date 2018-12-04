using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockSpawner : MonoBehaviour {

	//Constant Variables
	private const string ENEMY_PARENT_NAME = "Enemies";
	private const string SPAWN_METHOD = "Spawn";

	//Serialised Fields
	[SerializeField]
	private float spawnDelay = .2f;
	[SerializeField]
	private float spawnInterval = 1.3f;
	[SerializeField]
	private float enemyStartSpeed = 0f;
	private GameObject enemyParent;

	//Public Variables
	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;
	public GameObject Enemy4;
	public GameObject Boss;

	private void Start(){
		//Set The object that this script is attached to as a child of EnemyParent
		if(!enemyParent){
			enemyParent = new GameObject(ENEMY_PARENT_NAME);
		}

		//Get the Game Rules Singleton and 
		//Set the number of enemies to 9
		GameRules.Instance.setNoOfEnemies(9);

		//Repeatedly spawn enemies
		InvokeRepeating(SPAWN_METHOD, spawnDelay, spawnInterval);
	
	}
	
	private void Spawn(){

		//the game object that will be the enemy
		GameObject enemyChoice = null;
		
		//If the number of enemies is greater than none
		//if the number of enemies alive is less than the max number of enemies allowed to be alive
		//then spawn more enemies
		if( (GameRules.Instance.getNoOfEnemies() > 0) && (GameRules.Instance.maxEnemies > GameRules.Instance.getNoOfEnemiesAlive()) ){
			//Randomly select an enemy to spawn
			enemyChoice = randomEnemy();
			//spawn the random enemy
			spawnEnemies(enemyChoice);

		}
		//if there are no enemies alive
		if(GameRules.Instance.getNoOfEnemies() == 0){
			//choose the boss to spawn
			enemyChoice = Boss;
			//get the sound manager singleton, play the boss music
			SoundManager.Instance.PlayMusic(SoundManager.Instance.boss);
			//spawn the boss enemy
			spawnEnemies(enemyChoice);
		}

	}

	private GameObject randomEnemy(){
		//select the first enemy as default
		GameObject enemyChoice = Enemy1;

		//randomly select a number between 1 and 4, 
		//that will then select which enemy to spawn
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
		//return the selected enemy
		return enemyChoice;
	}

	private void spawnEnemies(GameObject enemyChoice){
			//Instantiate the Enemy at a position of its parent
			GameObject enemy = Instantiate(enemyChoice, enemyParent.transform);
			//set the enemy position, at this dockers position
			enemy.transform.position = transform.position;
			//get the waypoint component of this follower
			var follower = enemy.GetComponent<WaypointFollower>();
			//set the speed
			follower.Speed = enemyStartSpeed;
			//get the game rules singleton, 
			//set the no of enemies to 1 less than its current value
			GameRules.Instance.setNoOfEnemies(GameRules.Instance.getNoOfEnemies() - 1);
			//set the value of the number of enemies alive
			GameRules.Instance.setNoOfEnemiesAlive(GameRules.Instance.getNoOfEnemiesAlive() +1);
	}

}
