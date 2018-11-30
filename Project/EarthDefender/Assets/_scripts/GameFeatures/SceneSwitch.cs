using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

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
        GameRules.Instance.setNoOfEnemies(9);
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        SoundManager.Instance.PlayMusic(SoundManager.Instance.level1);
    }

    public void Level2()
    {
        GameRules.Instance.setNoOfEnemies(9);
        GameRules.Instance.setNoOfEnemiesAlive(0);
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        SoundManager.Instance.PlayMusic(SoundManager.Instance.level2);
    }

    public void Level3()
    {
        GameRules.Instance.setNoOfEnemies(9);
        GameRules.Instance.setNoOfEnemiesAlive(0);
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
        SoundManager.Instance.PlayMusic(SoundManager.Instance.level3);
    }
  
    public void endGame()
    {
        GameRules.Instance.setNoOfEnemies(9);
        ScoreKeeper.Instance.reset();
        GameRules.Instance.reset();
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

    
    public void Transition2()
    {
        SceneManager.LoadScene("Transition2", LoadSceneMode.Single);
        SoundManager.Instance.PlayMusic(SoundManager.Instance.MenuMusic);
    }
}
