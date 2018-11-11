using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour {

	private static GameRules _instance;
    public static GameRules Instance { get { return _instance; } }
	public int enemiesToSpawn = 9;
	public int maxEnemies = 2;
	public int enemiesAlive = 0;
	public bool torpUnlocked = false;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);

		if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
	}
	
}
