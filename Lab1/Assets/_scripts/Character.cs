using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    // Use this for initialization
    void Start () {

        //Add RigidBody
        gameObject.AddComponent<Rigidbody>();
        //Add a boxCollider
        BoxCollider bc = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
        //Set gravity on the Object
        GetComponent<Rigidbody>().useGravity = true;

    }
	
	// Update is called once per frame
	void Update () {

        //Bind our object to stay inside the Camera View
        BindObjectInCameraView();
        //Control our Character
        Controls();

    }

    void Controls() {

        //Move Right
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            transform.Translate(Vector3.right * Time.deltaTime*10, Space.World);
        }
        //Move Left
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            transform.Translate(Vector3.left * Time.deltaTime*10, Space.World);
        }

    }

    void BindObjectInCameraView() {

        //Clamp the Object to the Camera View
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);

    }
}
