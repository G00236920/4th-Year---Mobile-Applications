using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControls : MonoBehaviour {

    private PlayerPhysics Phys;

    // Use this for initialization
    void Start () {

        Phys = GetComponent<PlayerPhysics>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Phys.Fire();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Phys.ChangeWeaponType();
        }

    }
}
