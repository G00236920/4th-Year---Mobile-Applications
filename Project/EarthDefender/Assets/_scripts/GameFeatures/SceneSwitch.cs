using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {
    //Singleton scene switcher   
    private static SceneSwitch _instance;
    public static SceneSwitch Instance { get { return _instance; } }

	private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
    
    public void PlayGame()
    {
        //set the number of enemies back to normal for the first level
        GameRules.Instance.setNoOfEnemies(9);
        //load level 1
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        //set the music to music for level 1
        SoundManager.Instance.PlayMusic(SoundManager.Instance.level1);
    }

    public void Level2()
    {
        //set the number of enemies to 11
        GameRules.Instance.setNoOfEnemies(11);
        //make sure there are no enemies being counted from last game
        GameRules.Instance.setNoOfEnemiesAlive(0);
        //load level 2
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        //set music for level 2
        SoundManager.Instance.PlayMusic(SoundManager.Instance.level2);
    }

    public void Level3()
    {
        //set the number of enemies to 13
        GameRules.Instance.setNoOfEnemies(13);
        //make sure there are no enemies being counted from last game
        GameRules.Instance.setNoOfEnemiesAlive(0);
        //load level 3
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        //play music for level 3
        SoundManager.Instance.PlayMusic(SoundManager.Instance.level3);
    }
  
    public void endGame()
    {
        //reset back to 9 enemies for restarting
        GameRules.Instance.setNoOfEnemies(9);
        //reset score
        ScoreKeeper.Instance.reset();
        //reset in game rules
        GameRules.Instance.reset();
        //load the start screen
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }
    
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    public void Transition()
    {
        //show the first transition screen
        SceneManager.LoadScene("Transition", LoadSceneMode.Single);
        //change music
        SoundManager.Instance.PlayMusic(SoundManager.Instance.MenuMusic);
    }

    
    public void Transition2()
    {  
        //show the second transition screen
        SceneManager.LoadScene("Transition2", LoadSceneMode.Single);
        //change music
        SoundManager.Instance.PlayMusic(SoundManager.Instance.MenuMusic);
    }
}
