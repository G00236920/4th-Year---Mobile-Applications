using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	
	private static ScoreKeeper _instance;

    public static ScoreKeeper Instance { get { return _instance; } }

	public int score;

	void Start () {

		DontDestroyOnLoad(gameObject);

		if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

		score = 0;

	}
	
	// Update is called once per frame
	void Update () {

		GameObject scoreOutput = GameObject.Find("ScoreValue");

		if(scoreOutput!=null){
			Text scoreText = scoreOutput.GetComponent<Text>();
			scoreText.text = score.ToString();
		}
		
	}

}
