using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    private static SceneSwitch _instance;
    public static SceneSwitch Instance { get { return _instance; } }

    private int levelCount = 2;

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
        GameRules.Instance.enemiesToSpawn = 9;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        SoundManager.Instance.PlayMusic(SoundManager.Instance.level1);
    }

    public void nextLevel()
    {
        GameRules.Instance.enemiesToSpawn = 9;
        SceneManager.LoadScene("Level"+levelCount, LoadSceneMode.Single);
        SoundManager.Instance.PlayMusic(SoundManager.Instance.level1);
        levelCount++;
    }
  
    public void endGame()
    {
        GameRules.Instance.enemiesToSpawn = 9;
        ScoreKeeper.Instance.reset();
        GameRules.Instance.reset();
        levelCount = 2;
        SceneManager.LoadScene("StartScreen", LoadSceneMode.Single);
    }
    
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }

    public void Transition()
    {
        SceneManager.LoadScene("Transition", LoadSceneMode.Single);
        SoundManager.Instance.PlayMusic(SoundManager.Instance.MenuMusic);
    }
}
