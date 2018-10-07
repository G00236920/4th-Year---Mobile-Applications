using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour {

    public GameObject Phaser;
    public GameObject Torpedo;

    [SerializeField]
    private readonly float Thrust = 100;
    private GameObject WeaponType;

    private Rigidbody rb;

    void Start()
    {
        rb = transform.GetChild(0).gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.mass = 1;

        WeaponType = Phaser;
    }

    private void FixedUpdate()
    {

    }

    public void MoveForward()
    {
        rb.AddForce(Vector3.up *  Time.deltaTime * Thrust, ForceMode.Impulse);
    }

    public void MoveBackward()
    {
        rb.AddForce(Vector3.down *  Time.deltaTime * Thrust, ForceMode.Impulse);
    }

    public void MoveLeft()
    {
        rb.AddForce(Vector3.left *  Time.deltaTime * Thrust, ForceMode.Impulse);
    }

    public void MoveRight()
    {
        rb.AddForce(Vector3.right *  Time.deltaTime * Thrust, ForceMode.Impulse);
    }

    public void Stop()
    {
        rb.velocity = Vector3.zero;
    }

    public void Fire(){


        switch(WeaponType.name){
            case "PlayerPhaser":
                FirePhaser();
            break;
            case "PlayerTorpedo":
                FireTorpedo();
            break;
        }

    }

    public void ChangeWeaponType(){

        switch(WeaponType.name){
            case "PlayerPhaser":
                WeaponType = Torpedo;
            break;
            case "PlayerTorpedo":
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
