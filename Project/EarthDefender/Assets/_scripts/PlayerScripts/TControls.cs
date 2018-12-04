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

	void FixedUpdate(){
		Vector3 v;

		if (Input.touchCount != 1) {
			dragging = false; 
			return;
        }


		Touch touch = Input.touches[0];
		Vector3 pos = touch.position;

        if(touch.phase == TouchPhase.Began) {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(pos);

			if(Physics.Raycast(ray, out hit) && (hit.collider.tag == "Draggable"))
			{
				toDrag = hit.transform;
				
				dist = hit.transform.position.z - Camera.main.transform.position.z;
				
				v = new Vector3(pos.x, pos.y, dist);
				v = Camera.main.ScreenToWorldPoint(v);

				offset = toDrag.position - v;

				dragging = true;
			}

        }
		if (dragging && touch.phase == TouchPhase.Moved) {

			v = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
			v = Camera.main.ScreenToWorldPoint(v);
			toDrag.position = v + offset;

		}
		if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {

			dragging = false;
			
		}


	}
	
}
