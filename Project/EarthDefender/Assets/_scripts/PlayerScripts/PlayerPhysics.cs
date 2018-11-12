using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPhysics : MonoBehaviour {

    public GameObject Phaser;
    public GameObject Torpedo;
    public GameObject icon;
    public Sprite beamImage;
    public Sprite torpImage;
    [SerializeField]
    private readonly float Thrust = 10;
    private GameObject WeaponType;
    private Rigidbody rb;

    void Start(){
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        GameObject player = Instantiate(GameRules.Instance.getShip());
        player.transform.parent = gameObject.transform;

        rb = transform.GetChild(0).gameObject.AddComponent<Rigidbody>();
        rb.drag = 2F;
        rb.useGravity = false;
        rb.freezeRotation = true;
        WeaponType = Phaser;
    }

    void FixedUpdate ()
    {
        if(ScoreKeeper.Instance.getLives() >= 0){

            if(transform.childCount == 0){
                SpawnPlayer();
                ScoreKeeper.Instance.decreaseLives();
                return;
            }
            

            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");

            Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

            if( transform.childCount != 0){
                rb.AddForce (movement * Thrust);
            }
            
        }
        else{
            SceneSwitch.Instance.GameOver();
        }
        
    }

    void Update(){
        
        if( transform.childCount != 0){
            Vector3 pos = transform.GetChild(0).position;
            pos.z = 0;
            transform.GetChild(0).position = pos;
        }

    }

    public void Fire(){
        if( transform.childCount != 0){
            switch(WeaponType.name){
                case "PPhaser":
                    FirePhaser();
                break;
                case "PTorpedo":
                FireTorpedo();
                break;
            }
        }

    }

    public void ChangeWeaponType(){
            switch(WeaponType.name){
                case "PPhaser":
                    if(GameRules.Instance.getTorp()){
                        icon.GetComponent<Image>().sprite = torpImage;
                        WeaponType = Torpedo;   
                    }
                break;
                case "PTorpedo":
                    icon.GetComponent<Image>().sprite = beamImage;
                    WeaponType = Phaser;
                break;
            }
        

    }

    private void FirePhaser(){
        
        float x = this.gameObject.transform.GetChild(0).position.x - .2f;
        float y = this.gameObject.transform.GetChild(0).position.y + 1f;
        float z = this.gameObject.transform.GetChild(0).position.z;

        Instantiate(WeaponType, new Vector3(x,y,z), new Quaternion(0f,0f,0f,0f));

        x = this.gameObject.transform.GetChild(0).position.x + .2f;

        Instantiate(WeaponType, new Vector3(x,y,z), new Quaternion(0f,0f,0f,0f));

    }
    
    private void FireTorpedo(){
        
        float x = this.gameObject.transform.GetChild(0).position.x;
        float y = this.gameObject.transform.GetChild(0).position.y + 1f;
        float z = this.gameObject.transform.GetChild(0).position.z;

        Instantiate(WeaponType, new Vector3(x,y,z), new Quaternion(0f,0f,0f,0f));
    }

}
