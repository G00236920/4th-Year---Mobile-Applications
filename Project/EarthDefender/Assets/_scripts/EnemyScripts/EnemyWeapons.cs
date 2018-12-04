using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapons : MonoBehaviour {
	
	public GameObject phaser;
    [SerializeField]
    private bool MultiFire = false;

	// Update is called once per frame
	void Start(){
        //Repeatedly fire the phasers
		InvokeRepeating("FirePhaser", 0f, 1f);

	}

	
    private void FirePhaser(){
        //set the positions of the first phaser
        float x = this.gameObject.transform.GetChild(0).position.x - .2f;
        float y = this.gameObject.transform.GetChild(0).position.y - 1f;
        float z = this.gameObject.transform.GetChild(0).position.z;
        //create the phaser at that position
        Instantiate(phaser, new Vector3(x,y,z), new Quaternion(0f,0f,180f,0f));
        //set the position of the second phaser
        x = this.gameObject.transform.GetChild(0).position.x + .2f;
        //create the second phaser
        Instantiate(phaser, new Vector3(x,y,z), new Quaternion(0f,0f,180f,0f));

        //If enabled, Only bosses have this enabled.
        if(MultiFire)
        {
            //set the position of the first extra firable weapons
            x = this.gameObject.transform.GetChild(0).position.x - .4f;
            y = this.gameObject.transform.GetChild(0).position.y - 1f;
            z = this.gameObject.transform.GetChild(0).position.z;
            //create the first extra weapon
            var torpedo = Instantiate(phaser, new Vector3(x,y,z), new Quaternion(0f,0f,180f,0f));
            //rotate the phaser so that it fires at an angle
            torpedo.transform.Rotate(0, 0, -45);
            //set the position of the second extra weapon
            x = this.gameObject.transform.GetChild(0).position.x + .4f;
            //create the second weapon
            torpedo = Instantiate(phaser, new Vector3(x,y,z), new Quaternion(0f,0f,180f,0f));
            //rotat this weapon so it fires at a weapon
            torpedo.transform.Rotate(0, 0, 45);

        }

    }

}
