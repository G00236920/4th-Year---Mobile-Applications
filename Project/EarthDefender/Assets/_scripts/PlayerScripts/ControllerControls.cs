using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerControls : MonoBehaviour {

    private PlayerPhysics Phys;
    
	// Use this for initialization
	void Start () {
		
        Phys = GetComponent<PlayerPhysics>();
        
	}

	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKeyDown("joystick button 0"))
        {
            Phys.Fire();
        }

        if (Input.GetKeyDown("joystick button 2"))
        {
            Phys.ChangeWeaponType();
        }

        if (Input.GetKeyDown("joystick button 7"))
        {
            Phys.ChangeWeaponType();
        }

    }

}
