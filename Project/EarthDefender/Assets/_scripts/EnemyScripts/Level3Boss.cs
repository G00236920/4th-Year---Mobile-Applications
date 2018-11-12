using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Boss : MonoBehaviour {

    void OnDestroy()
    {
		  SceneSwitch.Instance.GameOver();
    }
}
