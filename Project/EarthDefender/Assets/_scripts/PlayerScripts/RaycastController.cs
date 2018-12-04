using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour {

    [SerializeField]
    private Transform viewPoint;
    [SerializeField]
    private LayerMask visibleObjects;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        var hit = Physics2D.Raycast(viewPoint.position, Vector2.left, 5f, visibleObjects);

        //Debug.DrawRay(viewPoint.position, new Vector2(-5f, 0), Color.yellow);

        if(hit && (hit.transform.name == "defiantPlayer(Clone)" || hit.transform.name == "enterprise_dPlayer(Clone)" || hit.transform.name == "prometheusPlayer(Clone)"))
        {
            Debug.Log("TEST");
        }

	}

}
