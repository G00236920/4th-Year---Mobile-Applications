using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    void OnDestroy()
    {
      //if the player is destroyed, lower the number of lives remaining
		  ScoreKeeper.Instance.decreaseLives();
    }

}
