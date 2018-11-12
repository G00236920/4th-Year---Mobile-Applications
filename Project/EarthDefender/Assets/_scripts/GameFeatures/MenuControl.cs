using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour {


    public GameObject AudioMenu;
    public GameObject HelpMenu;
    public GameObject MainMenu;
	
    public void Help(){
        MainMenu.SetActive(false);
        HelpMenu.SetActive(true);
    }

    public void AudioOptions()
    {
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

    public void StartGame()
    {
        SceneSwitch.Instance.PlayGame();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
