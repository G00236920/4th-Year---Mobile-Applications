using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputController : MonoBehaviour {

    private Touch touch;
    private PlayerPhysics Phys;

    void Start(){
        // player physics file
        Phys = GetComponent<PlayerPhysics>();

    }

    // Update is called once per frame
    void Update () {
        //if the object has children, ie. Player ship
        if( transform.childCount != 0){
            //check for touch controls
            HandleTouchInput();
        }

	}

    public void HandleTouchInput()
    {
        //if there are touches present
        if(Input.touchCount > 0)
        {
            //get the touches
            touch = Input.GetTouch(0);

            //create a position based on the touch input from the camera size
            Vector3 tPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0));

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    {
                        //if the count of touches is more than 1
                        if(Input.touchCount > 1){
                            //change weapon type
                            Phys.ChangeWeaponType();
                        }
                        //if there is one touch
                        if (Input.touchCount == 1){
                            //Fire a weapon
                            Phys.Fire();
                        }

                        break;
                    }
                //if the touch is dragged
                case TouchPhase.Moved:
                    {
                        //set the first childs position, ie player shiop, to the touch position
                        transform.GetChild(0).position = Vector3.Lerp(transform.GetChild(0).position, tPos, Time.deltaTime*5);

                        break;
                    }
                case TouchPhase.Ended:
                    {

                        break;
                    }
                case TouchPhase.Stationary:
                    {

                        break;
                    }
                case TouchPhase.Canceled:
                default:
                    break;
            }
        }

    }

}
