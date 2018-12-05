using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour {

	//Make sure the game rules are a singleton
	private static GameRules _instance;
    public static GameRules Instance { get { return _instance; } }

	//the number of enemies to spawn
	public static int enemiesToSpawn = 9;
	//The maximum number of enemies that can exist at a time
	public int maxEnemies = 2;
	//the number of enemies alive at the moment
	public static int enemiesAlive = 0;

	//identify if the items are unlocked
	private static bool torpUnlocked = false;
	public static bool defUnlocked = false;
	public static bool entUnlocked = false;

	//current ship choice
	private static GameObject shipChoice;
	//The ships to choose from
	public GameObject prometheus;
	public GameObject defiant;
	public GameObject enterprise;

	// Use this for initialization
	void Start () {

		//do not destroy this object
		DontDestroyOnLoad(gameObject);

		if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

		//set the ship as a prometheus by default
		shipChoice = prometheus;
	}

    private void Update()
    {
    }

    public void UnlockTorp(){

		//if the torpedos are locked
		if(!torpUnlocked){
			//if there are enough points to be unlocked
			if(ScoreKeeper.Instance.getScore() >= 1000)
			{
				//subtract the points from the score
				ScoreKeeper.Instance.setScore(1000);
				//unlock the torpedos
				setTorp(true);
			}

		}

    }

	public void SelectEnterprise(){
		
		//check if the enterprise is unlocked
		if(!ButtonController.Instance.getEnterpriseUnlocked()){
			//check if there are enough points to unlock
			if(ScoreKeeper.Instance.getScore() >= 3000)
			{
				//unlock the enterprise
				ButtonController.Instance.setEnterpriseUnlocked(true);
				//remove the points from the players score
				ScoreKeeper.Instance.setScore(3000);
			}
		}
		else{
			//set the ship as the enterprise
			setShip(enterprise);
		}

	}

	private void SelectDefiant(){
		//check if the defiant is unlocked
		if(!ButtonController.Instance.getDefiantUnlocked()){
			//check if there are enough points to unlock it
			if(ScoreKeeper.Instance.getScore() >= 2000)
			{
				//set it as unlocked
				ButtonController.Instance.setDefiantUnlocked(true);
				//subtract the points from player score
				ScoreKeeper.Instance.setScore(2000);
			}
		}
		else{
			//set players ship as defiant
			setShip(defiant);
		}
		
	}

	public void SelectPrometheus(){
		//set the ship
		setShip(prometheus);
	}
	
	public void setTorp(bool b){
		//unlock torps
		torpUnlocked = b;
	}

	public bool getTorp(){
		//check if the torps are unlocked
		return torpUnlocked;
	}

	public void setShip(GameObject s){
		//set current ship chosen
		shipChoice = s;
	}

	public GameObject getShip(){
		//return the current ship choice
		return shipChoice;
	}

	public void reset(){

		//reset these values when new game starts
		shipChoice = prometheus;
		enemiesToSpawn = 9;
		enemiesAlive = 0;
		torpUnlocked = false;
		defUnlocked = false;
		entUnlocked = false;

	}

	public int getNoOfEnemies(){
		//the number of enemies that should be spawned
		return enemiesToSpawn;
	}

	public void setNoOfEnemies(int n){
		//set the number of enemies to spawn
		enemiesToSpawn = n;
	}

	public int getNoOfEnemiesAlive(){
		//return how many enemies exist now
		return enemiesAlive;
	}

	public void setNoOfEnemiesAlive(int n){
		//set the number of enemies alive
		enemiesAlive = n;
	}
}
