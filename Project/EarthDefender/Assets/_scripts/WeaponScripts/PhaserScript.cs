using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaserScript : MonoBehaviour {

	[SerializeField]
	private float thrust = 30;
	[SerializeField]
	private Color col = new Color(0,0,0, .02f);
	[SerializeField]
	private bool playerWeapon = true;
	private Rigidbody rb;


	// Use this for initialization
	void Start () {

		rb = transform.gameObject.AddComponent<Rigidbody>();
		gameObject.AddComponent<TrailRenderer>();

		gameObject.GetComponent<Renderer>().material.color = col;

		TrailRenderer trail = gameObject.GetComponent<TrailRenderer>();

		trail.widthMultiplier =  .04f;
		trail.material.SetColor("_Color", col);
		trail.material.SetColor("_TintColor", new Color(0,0,0,.02f));
		trail.time = .08f ;
		
		rb.useGravity = false;
		
		if(playerWeapon)
			SoundManager.Instance.Play(SoundManager.Instance.beam);
		else
			SoundManager.Instance.PlayEnemy(SoundManager.Instance.beam);

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
		if(collision.gameObject.name.Contains("Enemy") && playerWeapon){

			int health = collision.collider.gameObject.GetComponent<EnemyHealth>().health;
			int damage = collision.collider.gameObject.GetComponent<EnemyHealth>().damagePerHitTaken/2;

			collision.collider.gameObject.GetComponent<EnemyHealth>().health = health - damage;

			Destroy(gameObject);

		}
		if(collision.gameObject.name.Contains("Player") && !playerWeapon){
			Destroy(collision.gameObject);
		}

    }

}
