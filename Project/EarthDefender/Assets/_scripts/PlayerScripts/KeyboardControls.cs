using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour {

    private PlayerPhysics Phys;

    // Use this for initialization
    void Start () {
        //get the physics script
        Phys = GetComponent<PlayerPhysics>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //if the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //fire the weapon
            Phys.Fire();
        }
        //if the control key is pressed
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //change the weapon type
            Phys.ChangeWeaponType();
        }

    }
}
