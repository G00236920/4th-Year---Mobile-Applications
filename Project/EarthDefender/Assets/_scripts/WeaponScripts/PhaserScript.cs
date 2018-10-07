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
		rb.useGravity = false;

	}

	void Update(){
		Object.Destroy(gameObject, 2.0f);
	}

	// Update is called once per frame
	void FixedUpdate () {

		rb.AddForce(transform.up *  Time.deltaTime * thrust, ForceMode.Impulse);

	}
}
