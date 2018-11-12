using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Boss : MonoBehaviour {

    void OnDestroy()
    {
		  SceneSwitch.Instance.Transition();
    }

}
