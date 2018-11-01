using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaypointFollower : MonoBehaviour {

private IList<Vector3> waypoints = new List<Vector3>();
private Vector3 currentWaypoint;
private float speed;
private Rigidbody rb;

public float Speed { get { return speed; } set { speed = value; } }

	private void Start(){

		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;

		NextPointToFollow();

	}

	private void FixedUpdate(){

		if(HasMorePoints()) {

			Move();

		}

	}

	void Update(){
				
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;

	}

	private void NextPointToFollow(){

		if(HasMorePoints()) {

			currentWaypoint = waypoints.First();

		}

	}

	private void Move(){

		rb.position = Vector3.MoveTowards(rb.position, currentWaypoint, speed * Time.deltaTime);

		if(Vector3.Distance(rb.position, currentWaypoint) < 0.01){

			rb.position = new Vector2(currentWaypoint.x, currentWaypoint.y);

			waypoints.Remove(currentWaypoint);

			if(HasMorePoints()) {

				NextPointToFollow();

			}

		}

	}

	private bool HasMorePoints(){

		return waypoints.Count != 0;

	}

	public void AddPointsToFollow(Vector3 point){

		waypoints.Add(point);

	}

}
