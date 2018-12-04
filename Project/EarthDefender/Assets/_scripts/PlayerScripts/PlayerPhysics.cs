using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPhysics : MonoBehaviour {

    //Weapon Objects
    public GameObject Phaser;
    public GameObject Torpedo;
    public GameObject icon;

    //icon used for beams
    public Sprite beamImage;
    //icon for torpedo
    public Sprite torpImage;

    //thrust for weapons to fire at
    [SerializeField]
    private readonly float Thrust = 10;
    //the current weapon type
    private GameObject WeaponType;
    //weapons rigid body
    private Rigidbody rb;

    void Start(){
        //spawn a player
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        //create a ship and instantiate
        GameObject player = Instantiate(GameRules.Instance.getShip());
        //set the ship to be a child of the player object
        player.transform.parent = gameObject.transform;
        //give the ship a rigidbody, the last one was probably destoyed
        rb = transform.GetChild(0).gameObject.AddComponent<Rigidbody>();
        //add drag so the force added wont be continous
        rb.drag = 2F;
        //disable gravity effect
        rb.useGravity = false;
        //freeze rotation
        rb.freezeRotation = true;
        //set weapontype as phaser by default
        WeaponType = Phaser;
    }

    void FixedUpdate ()
    {
        //if the player still has lives left
        if(ScoreKeeper.Instance.getLives() >= 0){
            //if the player object has no children
            if(transform.childCount == 0){
                //spawn a new player
                SpawnPlayer();
                //decrease the lives the player has left
                ScoreKeeper.Instance.decreaseLives();
                return;
            }
            
            //Movement options, to control the ship movements
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");

            //use movement
            Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

            //if the object has children
            if( transform.childCount != 0){
                //add force to the object
                rb.AddForce (movement * Thrust);
            }
            
        }
        else{
            //switch the scene, to the end of the game
            SceneSwitch.Instance.GameOver();
        }
        
    }

    void Update(){
        //if the player object has an object
        if( transform.childCount != 0){
            //get the position
            Vector3 pos = transform.GetChild(0).position;
            //set the z axis of the object
            pos.z = 0;
            //set the position
            transform.GetChild(0).position = pos;
        }

    }

    public void Fire(){
        //if the player object has children
        if( transform.childCount != 0){
            //which ever weapon type been used
            switch(WeaponType.name){
                case "PPhaser":
                    //fire a phaser
                    FirePhaser();
                break;
                case "PTorpedo":
                    //Fire Torpedo
                    FireTorpedo();
                break;
            }
        }

    }

    public void ChangeWeaponType(){
            //Change the weapon type
            switch(WeaponType.name){
                case "PPhaser":

                    //if torpedos are unlocked
                    if(GameRules.Instance.getTorp()){
                        //change the icon to torpedo
                        icon.GetComponent<Image>().sprite = torpImage;
                        WeaponType = Torpedo;   
                    }
                break;
                case "PTorpedo":
                    //change the icon to phaser
                    icon.GetComponent<Image>().sprite = beamImage;
                    WeaponType = Phaser;
                break;
            }
        

    }

    private void FirePhaser(){
        
        //set the position of the phaser weapons
        //left and right of the front of the ship
        float x = this.gameObject.transform.GetChild(0).position.x - .2f;
        float y = this.gameObject.transform.GetChild(0).position.y + 1f;
        float z = this.gameObject.transform.GetChild(0).position.z;

        //create the weapon
        Instantiate(WeaponType, new Vector3(x,y,z), new Quaternion(0f,0f,0f,0f));
        //position of the second phaser
        x = this.gameObject.transform.GetChild(0).position.x + .2f;
        //create the weapon
        Instantiate(WeaponType, new Vector3(x,y,z), new Quaternion(0f,0f,0f,0f));

    }
    
    private void FireTorpedo(){
        //position the torpedo, center of the front of the ship
        float x = this.gameObject.transform.GetChild(0).position.x;
        float y = this.gameObject.transform.GetChild(0).position.y + 1f;
        float z = this.gameObject.transform.GetChild(0).position.z;
        //create the weapon
        Instantiate(WeaponType, new Vector3(x,y,z), new Quaternion(0f,0f,0f,0f));
    }

}
