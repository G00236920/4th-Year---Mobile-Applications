using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
