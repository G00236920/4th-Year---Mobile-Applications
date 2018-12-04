using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        //keep the object this script is attached to, within the view of the camera
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
