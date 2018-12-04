using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour {

    //different menus
    public GameObject AudioMenu;
    public GameObject HelpMenu;
    public GameObject MainMenu;
	
    //set the help menu as primary
    public void Help(){
        MainMenu.SetActive(false);
        HelpMenu.SetActive(true);
    }

    //set the audio menu as primary
    public void AudioOptions()
    {
        MainMenu.SetActive(false);
        AudioMenu.SetActive(true);
    }

    //return to the main menu
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

    //begin a new game
    public void StartGame()
    {
        SceneSwitch.Instance.PlayGame();
    }
    
    //quit the program
    public void Quit()
    {
        Application.Quit();
    }
}
