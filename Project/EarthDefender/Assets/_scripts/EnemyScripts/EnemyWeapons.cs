using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapons : MonoBehaviour {
	
	public GameObject phaser;

	// Update is called once per frame
	void Start(){

		//InvokeRepeating("FirePhaser", 0f, 1f);

	}

	
    private void FirePhaser(){
        
        float x = this.gameObject.transform.GetChild(0).position.x - .2f;
        float y = this.gameObject.transform.GetChild(0).position.y - 1f;
        float z = this.gameObject.transform.GetChild(0).position.z;

        Instantiate(phaser, new Vector3(x,y,z), new Quaternion(0f,0f,180f,0f));

        x = this.gameObject.transform.GetChild(0).position.x + .2f;

        Instantiate(phaser, new Vector3(x,y,z), new Quaternion(0f,0f,180f,0f));

    }

}
