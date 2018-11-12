using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Boss : MonoBehaviour {

    void OnDestroy()
    {
		  SceneSwitch.Instance.Transition2();
    }

}
