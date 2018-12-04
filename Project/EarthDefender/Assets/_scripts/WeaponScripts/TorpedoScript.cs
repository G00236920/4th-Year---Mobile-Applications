using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : MonoBehaviour {
	//speed of the weapon
	[SerializeField]
	private float thrust = 20;
	//rigid body of the weapon
	private Rigidbody rb;

	
	void Start () {
		//add a rigidbody
		rb = transform.gameObject.AddComponent<Rigidbody>();
		//trail renderer
		gameObject.AddComponent<TrailRenderer>();
		//set the colour of the trail
		gameObject.GetComponent<Renderer>().material.color = new Color(212,175,55,.1f);
		//get the trail
		TrailRenderer trail = gameObject.GetComponent<TrailRenderer>();

		//trail attributes
		trail.widthMultiplier =  .04f;
		trail.material.SetColor("_Color", new Color(212,175,55, .02f));
		trail.material.SetColor("_TintColor", new Color(0,0,0,.02f));
		trail.time = .01f ;
		
		//disable gravity
		rb.useGravity = false;
		//play the torpedo sound
		SoundManager.Instance.Play(SoundManager.Instance.torpedo);

	}

	void Update(){
		//destroy the torpedo after a time
		Object.Destroy(gameObject, 2.0f);
	}

	// Update is called once per frame
	void FixedUpdate () {
		//add force to the object
		rb.AddForce(transform.up *  Time.deltaTime * thrust, ForceMode.Impulse);

	}

	void OnCollisionEnter(Collision collision)
    {	
		//if the object hits an object with the same name
		if(collision.gameObject.name == gameObject.name){
			return;
		}
		//if the object hits an enemy object
		if(collision.gameObject.name.Contains("Enemy")){
			
			//Destroy(collision.collider.gameObject);
			//get the health value of enemy
			int health = collision.collider.gameObject.GetComponent<EnemyHealth>().health;
			//get the damage value
			int damage = collision.collider.gameObject.GetComponent<EnemyHealth>().damagePerHitTaken;
			//set the health, to health less than the damage value
			collision.collider.gameObject.GetComponent<EnemyHealth>().health = health - damage;
			//destroy the enemy
			Destroy(gameObject);
			
		}

    }

}