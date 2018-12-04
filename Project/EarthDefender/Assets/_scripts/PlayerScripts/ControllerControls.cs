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


        //if the A button on an xbox controller is down
        if (Input.GetKeyDown("joystick button 0"))
        {
            // fire the weapon
            Phys.Fire();
        }
        //if the X button on an XBox controller is down
        if (Input.GetKeyDown("joystick button 2"))
        {
            //change the weapon type
            Phys.ChangeWeaponType();
        }
        //if the start button is pressed
        if (Input.GetKeyDown("joystick button 7"))
        {   
            //pause the game
            //placed in another script
        }

    }

}
