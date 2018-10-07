using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaserScript : MonoBehaviour {

	[SerializeField]
	private float thrust = 30;

	private Rigidbody rb;


	// Use this for initialization
	void Start () {

		rb = transform.gameObject.AddComponent<Rigidbody>();
		gameObject.AddComponent<TrailRenderer>();

		gameObject.GetComponent<Renderer>().material.color = new Color(255,0,0,.1f);

		TrailRenderer trail = gameObject.GetComponent<TrailRenderer>();

		trail.widthMultiplier =  .04f;
		trail.material.SetColor("_Color", new Color(255,0,0, .02f));
		trail.material.SetColor("_TintColor", new Color(0,0,0,.02f));
		trail.time = .08f ;
		
		rb.useGravity = false;

	}

	void Update(){
		Object.Destroy(gameObject, 2.0f);
	}

	// Update is called once per frame
	void FixedUpdate () {

		rb.AddForce(transform.up *  Time.deltaTime * thrust, ForceMode.Impulse);

	}

	void OnCollisionEnter(Collision collision)
    {
		if(collision.gameObject.name == gameObject.name){
			return;
		}
		Destroy(collision.collider.gameObject);
		Destroy(gameObject);

    }

}
