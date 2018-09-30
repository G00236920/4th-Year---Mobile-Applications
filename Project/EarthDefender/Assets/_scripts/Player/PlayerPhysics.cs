using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour {

    [SerializeField]
    private readonly float Thrust = 10;

    private Rigidbody rb;

    void Start()
    {
        rb = transform.GetChild(0).gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.mass = 1;
    }

    private void FixedUpdate()
    {

    }

    public void MoveForward()
    {
        rb.AddForce(Vector3.up * Thrust, ForceMode.VelocityChange);
    }

    public void MoveBackward()
    {
        rb.AddForce(Vector3.down * Thrust, ForceMode.VelocityChange);
    }

    public void MoveLeft()
    {
        rb.AddForce(Vector3.left * Thrust, ForceMode.VelocityChange);
    }

    public void MoveRight()
    {
        rb.AddForce(Vector3.right * Thrust, ForceMode.VelocityChange);
    }

    public void Stop()
    {
        rb.velocity = Vector3.zero;
    }

}
