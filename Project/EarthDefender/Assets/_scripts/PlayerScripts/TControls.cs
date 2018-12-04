using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TControls : MonoBehaviour {

    private PlayerPhysics Phys;
	private bool dragging = false;
	private float dist;
	private Vector3 offset;
	private Transform toDrag;


	// Use this for initialization
	void Start () {
		
        Phys = GetComponent<PlayerPhysics>();
		
	}

	void Update(){

		for(var touch : Touch in Input.touches)
		{

			if(touch.phase == TouchPhase.Began)
			{

				var ray = Camera.main.ScreenPointToRay(touch.position);

				if(Physics.RayCast(ray)){

					Debug.Log("test");

				}

			}

		}

	}
	
}
