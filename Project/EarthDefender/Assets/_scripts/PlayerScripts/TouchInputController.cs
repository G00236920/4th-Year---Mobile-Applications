using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputController : MonoBehaviour {

    private Touch touch;
    private Vector2 startPosition;
    private Vector2 lastPosition;

    private SpriteRenderer sr;

    private bool touchPointer;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update () {
        HandleTouchInput();
	}

    private void HandleTouchInput()
    {
        // check if there is a touch input, 
        // check if its on the circle (raycast)
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    {
                        startPosition = touch.position;
                        touchPointer = CheckForPlayerObject();
                        break;
                    }
                case TouchPhase.Moved:
                    {
                        //Vector2 currentScreenPoint = new Vector2(
                        //    touch.position.x, touch.position.y);
                        //offset = transform.position - 
                        //        Camera.main.ScreenToWorldPoint(
                        //                new Vector2(touch.position.x, 
                        //                            touch.position.y));

                        Vector2 touchPosition =
                            Camera.main.ScreenToWorldPoint(
                                touch.position);
                        transform.position = touchPosition;

                        //Rigidbody2D rb = GetComponent<Rigidbody2D>();
                        //rb.velocity = touch.deltaPosition;
                        lastPosition = transform.position;
                        break;
                    }
                case TouchPhase.Ended:
                    {
                        if (touchPointer)
                        {
                            sr.color = Color.white;
                        }
                        break;
                    }
                case TouchPhase.Stationary:
                    {
                        if(touchPointer)
                        {
                            sr.color = Color.red;
                        }
                        break;
                    }
                case TouchPhase.Canceled:
                default:
                    break;
            }
        }

    }

    private bool CheckForPlayerObject()
    {
        touchPointer = false;
        // raycast from user's finger to the player to see if they are 
        // touching it.
        Vector2 origin = Camera.main.ScreenToWorldPoint(touch.position);
        var hit = Physics2D.Raycast(origin,
                                    startPosition);
        if( hit && hit.transform.name == "Circle")
        {
            touchPointer = true;
        }

        return touchPointer;
    }
}
