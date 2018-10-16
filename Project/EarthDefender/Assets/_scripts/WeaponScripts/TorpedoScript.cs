using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour {

	[SerializeField]
	private float thrust = 20;

	private Rigidbody rb;

	
	void Start () {

		rb = transform.gameObject.AddComponent<Rigidbody>();
		gameObject.AddComponent<TrailRenderer>();

		gameObject.GetComponent<Renderer>().material.color = new Color(212,175,55,.1f);

		TrailRenderer trail = gameObject.GetComponent<TrailRenderer>();

		trail.widthMultiplier =  .04f;
		trail.material.SetColor("_Color", new Color(212,175,55, .02f));
		trail.material.SetColor("_TintColor", new Color(0,0,0,.02f));
		trail.time = .01f ;
		
		rb.useGravity = false;

		SoundManager.Instance.Play(SoundManager.Instance.torpedo);

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
		if(collision.gameObject.name == gameObject.name){
			return;
		}
		if(collision.gameObject.name.Contains("Enemy")){

			//Destroy(collision.collider.gameObject);
			int health = collision.collider.gameObject.GetComponent<EnemyHealth>().health;
			int damage = collision.collider.gameObject.GetComponent<EnemyHealth>().damagePerHitTaken;

			collision.collider.gameObject.GetComponent<EnemyHealth>().health = health - damage;

			Destroy(gameObject);
			
		}

    }

}