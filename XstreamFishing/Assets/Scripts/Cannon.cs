using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class serves as a "spawn" for cannonball prefabs

public class Cannon : MonoBehaviour
{

    public Cannonball cannonball;
    public float barrelSpeed;
    public float fireDelay;
    public float gimbalSpeed = 1;
    

    void Start()
    {

    }

    void Update() {
        if(Input.GetKeyDown("b")) {
            Fire();
        }
        if(Input.GetKey("g")) {
            GimbalDown();
        }
        if(Input.GetKey("y")) {
            GimbalUp();
        }


    }

    void Fire() {
        Cannonball newCannonball = cannonball.GetPooledInstance<Cannonball>();
        Rigidbody rb = newCannonball.GetComponent<Rigidbody>();
        Vector3 unitBarrelDir = new Vector3(Mathf.Cos(transform.rotation.z), Mathf.Sin(transform.rotation.z), 0f);
        newCannonball.transform.position = transform.position;
        rb.velocity = Vector3.zero;
        rb.AddForce(transform.rotation*Vector3.up*barrelSpeed);
    }

    void GimbalUp() {
        transform.Rotate(0, 0, -gimbalSpeed);
    }

    void GimbalDown() {
        transform.Rotate(0, 0, gimbalSpeed);
    }
}
