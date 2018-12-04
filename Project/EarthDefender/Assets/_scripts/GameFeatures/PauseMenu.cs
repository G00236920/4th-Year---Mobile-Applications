using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject inGameMenu;
	public GameObject Overlay;
	private bool paused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
		{

			if(paused)
			{
				unPauseGame();
			}
			else
			{
				pauseGame();
			}

		}
	}

	public void pauseGame(){

		Time.timeScale = 0;

		paused = true;
		inGameMenu.SetActive(true);
		Overlay.SetActive(false);
		
	}

	void unPauseGame(){

		Time.timeScale = 1;

		paused = false;
		inGameMenu.SetActive(false);
		Overlay.SetActive(true);

	}
}
