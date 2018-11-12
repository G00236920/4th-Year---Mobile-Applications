using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour {

	private static GameRules _instance;
    public static GameRules Instance { get { return _instance; } }
	public int enemiesToSpawn = 9;
	public int maxEnemies = 2;
	public int enemiesAlive = 0;
	private static bool torpUnlocked = false;
	public bool defUnlocked = false;
	public bool entUnlocked = false;
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

	public void UnlockTorp(){
		setTorp(true);
	}

	public void SelectEnterprise(){
		setShip(enterprise);
	}

	private void SelectDefiant(){
		setShip(defiant);
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

		enemiesToSpawn = 9;
		torpUnlocked = false;
		defUnlocked = false;
		entUnlocked = false;

	}
}
