using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputController : MonoBehaviour {

    private Touch touch;
    private PlayerPhysics Phys;

    void Start(){

        Phys = GetComponent<PlayerPhysics>();

    }

    // Update is called once per frame
    void Update () {

        if( transform.childCount != 0){
            HandleTouchInput();
        }

	}

    public void HandleTouchInput()
    {

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            Vector3 tPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0));

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    {
                        if(Input.touchCount > 1){
                            Phys.ChangeWeaponType();
                        }
                        if (Input.touchCount == 1){
                            Phys.Fire();
                        }

                        break;
                    }
                case TouchPhase.Moved:
                    {

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
