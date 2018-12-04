using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Boss : MonoBehaviour {

    void OnDestroy()
    {
        //if this boss dies, transition to the transition before the third level
		SceneSwitch.Instance.Transition2();
    }

}
