using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {
	//the pause menu that will be shown in game
	public GameObject inGameMenu;
	//the overlay shown during the game
	public GameObject Overlay;
	//is the game currently paused or not
	private bool paused = false;
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
		{
			//if the game is paused, unpause it
			if(paused)
			{
				unPauseGame();
			}
			//if the game is not paused, pause it
			else
			{
				pauseGame();
			}

		}
	}

	//pause the game
	public void pauseGame(){
		//this pause the gameplay
		Time.timeScale = 0;
		paused = true;

		//set the canvas
		inGameMenu.SetActive(true);
		Overlay.SetActive(false);
		
	}

	void unPauseGame(){
		//return to normal gameplay
		Time.timeScale = 1;
		paused = false;

		//set the canvas
		inGameMenu.SetActive(false);
		Overlay.SetActive(true);

	}
}
