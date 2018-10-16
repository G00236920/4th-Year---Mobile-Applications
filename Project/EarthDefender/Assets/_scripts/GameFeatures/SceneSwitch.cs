using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    public GameObject AudioMenu;
    public GameObject HelpMenu;
    public GameObject MainMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        SoundManager.Instance.PlayMusic(SoundManager.Instance.level1);
    }

    public void Help(){
        MainMenu.SetActive(false);
        HelpMenu.SetActive(true);
    }

    public void AudioOptions(){
        MainMenu.SetActive(false);
        AudioMenu.SetActive(true);
    }

    
    public void Back()
    {
        if(AudioMenu){
            AudioMenu.SetActive(false);
        }
        if(HelpMenu){
            HelpMenu.SetActive(false);
        }

        MainMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
