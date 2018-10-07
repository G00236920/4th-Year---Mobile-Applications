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

        if (Input.GetKeyDown(KeyCode.W))
        {
            Phys.MoveForward();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            Phys.Stop();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Phys.MoveLeft();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Phys.Stop();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Phys.MoveBackward();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Phys.Stop();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Phys.MoveRight();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Phys.Stop();
        }

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
