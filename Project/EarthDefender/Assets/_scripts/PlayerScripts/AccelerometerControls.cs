using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerControls : MonoBehaviour {

    private PlayerPhysics Phys;

	// Use this for initialization
	void Start () {
		
        Phys = GetComponent<PlayerPhysics>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetTouch(1).phase == TouchPhase.Began)
        {
            Phys.Fire();
        }
    
        if (Input.GetTouch(2).phase == TouchPhase.Began)
        {
            Phys.ChangeWeaponType();
        }

    }
}
