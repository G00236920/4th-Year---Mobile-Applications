using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    void OnDestroy()
    {
		ScoreKeeper.Instance.decreaseLives();

    }

}
