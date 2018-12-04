using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Boss : MonoBehaviour {

    void OnDestroy()
    {
        //if this boss dies, then the game is over and the player wins
		SceneSwitch.Instance.GameOver();
    }
}
