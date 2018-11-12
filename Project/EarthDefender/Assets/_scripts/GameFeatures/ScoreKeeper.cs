using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	
	private static ScoreKeeper _instance;

    public static ScoreKeeper Instance { get { return _instance; } }

	public int score;
	
	private static int lives = 3;

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
		GameObject livesOutput = GameObject.Find("LivesLeft");

		if(scoreOutput!=null){
			Text scoreText = scoreOutput.GetComponent<Text>();
			scoreText.text = score.ToString();
		}

		if(livesOutput!=null){
			Text liveText = livesOutput.GetComponent<Text>();
			liveText.text = lives.ToString();
		}
		
	}

	public void reset(){
		setLives(3);
		score = 0;
	}

	public void setLives(int l){
		lives = l;
	}

	public void decreaseLives(){
		lives--;
	}

	public void increaseLives(){
		lives++;
	}
	public int getLives(){
		return lives;
	}

}
