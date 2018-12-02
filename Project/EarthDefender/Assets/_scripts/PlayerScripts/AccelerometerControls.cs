using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerControls : MonoBehaviour {

    private PlayerPhysics Phys;

	// Use this for initialization
	void Start () {
		
        Phys = GetComponent<PlayerPhysics>();
		
	}
	
}
