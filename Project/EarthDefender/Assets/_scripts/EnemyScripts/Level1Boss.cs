using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Boss : MonoBehaviour {

    void OnDestroy()
    {
        //if this boss dies, got to the transition screen before the second level
		SceneSwitch.Instance.Transition();
    }

}
