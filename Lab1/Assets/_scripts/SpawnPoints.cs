using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {

    public GameObject Bomb;
    private float Timer = 2;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

        //Set the Timer
        Timer -= Time.deltaTime;

        //If the timer drops to 0
        if (Timer <= 0)
        {
            //Instantiate a Bomb
            Instantiate(Bomb, transform.position, Quaternion.identity);
            //Reset the Timer
            Timer = 2f;
        }

    }
}
