using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	
	private static ScoreKeeper _instance;

    public static ScoreKeeper Instance { get { return _instance; } }

	//players score
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
		//reset score
		score = 0;

	}
	
	// Update is called once per frame
	void Update () {
		//Find the score value on screen
		GameObject scoreOutput = GameObject.Find("ScoreValue");
		//find the on screen area for the number of lives remaining
		GameObject livesOutput = GameObject.Find("LivesLeft");

		if(scoreOutput!=null){
			//if the scoreoutput exists, get the component
			Text scoreText = scoreOutput.GetComponent<Text>();
			//convert to a string
			scoreText.text = score.ToString();
		}

		if(livesOutput!=null){
			//get the text from the lives remaining
			Text liveText = livesOutput.GetComponent<Text>();
			//convert to a string
			liveText.text = lives.ToString();
		}
		
	}

	public void reset(){
		//reset lives to 3
		setLives(3);
		//reset score to 0
		score = 0;
	}

	public void setLives(int l){
		//set number of lives
		lives = l;
	}

	public void decreaseLives(){
		//decrease number of lives
		lives--;
	}

	public void increaseLives(){
		//increase number of lives
		lives++;
	}
	public int getLives(){
		//return number of lives
		return lives;
	}

	public int getScore(){
		//return the score
		return score;
	}

	public void setScore(int value){
		//reduce the score by this value
		score -= value;
	}

}
