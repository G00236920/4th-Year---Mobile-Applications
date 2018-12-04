using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour {

	private static GameRules _instance;
    public static GameRules Instance { get { return _instance; } }
	public static int enemiesToSpawn = 9;
	public int maxEnemies = 2;
	public static int enemiesAlive = 0;
	private static bool torpUnlocked = false;
	public static bool defUnlocked = false;
	public static bool entUnlocked = false;
	private static GameObject shipChoice;
	public GameObject prometheus;
	public GameObject defiant;
	public GameObject enterprise;

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad(gameObject);

		if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

		shipChoice = prometheus;
	}

    private void Update()
    {
    }

    public void UnlockTorp(){

		if(!torpUnlocked){

			if(ScoreKeeper.Instance.getScore() > 1000)
			{
				ScoreKeeper.Instance.setScore(1000);
				setTorp(true);
			}

		}

    }

	public void SelectEnterprise(){
		
		if(!ButtonController.Instance.getEnterpriseUnlocked()){
			if(ScoreKeeper.Instance.getScore() > 3000)
			{
				ButtonController.Instance.setEnterpriseUnlocked(true);
				ScoreKeeper.Instance.setScore(3000);
			}
		}
		else{
			setShip(enterprise);
		}

	}

	private void SelectDefiant(){
		
		if(!ButtonController.Instance.getDefiantUnlocked()){

			if(ScoreKeeper.Instance.getScore() > 2000)
			{
				ButtonController.Instance.setDefiantUnlocked(true);
				ScoreKeeper.Instance.setScore(2000);
			}
		}
		else{
			setShip(defiant);
		}
		
	}

	public void SelectPrometheus(){
		setShip(prometheus);
	}
	
	public void setTorp(bool b){
		torpUnlocked = b;
	}

	public bool getTorp(){
		return torpUnlocked;
	}

	public void setShip(GameObject s){
		shipChoice = s;
	}

	public GameObject getShip(){
		return shipChoice;
	}

	public void reset(){

		shipChoice = prometheus;
		enemiesToSpawn = 9;
		enemiesAlive = 0;
		torpUnlocked = false;
		defUnlocked = false;
		entUnlocked = false;

	}

	public int getNoOfEnemies(){
		return enemiesToSpawn;
	}

	public void setNoOfEnemies(int n){
		enemiesToSpawn = n;
	}

	public int getNoOfEnemiesAlive(){
		return enemiesAlive;
	}

	public void setNoOfEnemiesAlive(int n){
		enemiesAlive = n;
	}
}
