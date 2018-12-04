using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaypointFollower : MonoBehaviour {

private Vector3 currentWaypoint;
//next way point to follow
private float speed;
//rigid body of the follower
private Rigidbody rb;
//sets and getters for speed
public float Speed { get { return speed; } set { speed = value; } }

	private void Start(){
		//get the rigid body of this object
		rb = GetComponent<Rigidbody>();
		//freeze its rotation, so it cant turn
		rb.freezeRotation = true;
		//stop the object from being affected by kinectic forces
		rb.isKinematic = true;

		//get the next waypoint to follow
		NextPointToFollow();

	}

	private void FixedUpdate(){
		//move on update
		Move();

	}

	void Update(){
		//this position
		Vector3 pos = transform.position;
		//stop from moving on the Z axis
		pos.z = 0;
		//set the position again
		transform.position = pos;

	}

	private void NextPointToFollow(){
		//get a list of points to go to
		List<Transform> points = WayPoints.Instance.getPoints();
		//Shuffle the list of waypoints
		points = points.OrderBy( x => Random.value ).ToList();
		//set the next waypoint to that of the first waypoint in the list
		currentWaypoint = points.First().position;

	}

	private void Move(){
		//set the rigidbody of the object and make it go towards the next waypoint
		rb.position = Vector3.MoveTowards(rb.position, currentWaypoint, speed * Time.deltaTime);

		//if the object is almost at the position of the waypoint
		if(Vector3.Distance(rb.position, currentWaypoint) < 0.01)	{
			//set it to the position of the waypoint
			rb.position = new Vector2(currentWaypoint.x, currentWaypoint.y);
			//get a new waypoint to follow
			NextPointToFollow();

		}

	}

}