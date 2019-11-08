using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class serves as a "spawn" for cannonball prefabs

public class Cannon : MonoBehaviour
{

    // ParticleSystem ps;
    public Cannonball cannonball;
    public float barrelSpeed;
    public float fireDelay;
    float fireTimer = -1;
    public float gimbalSpeed = 1;
    public Inventory inventory;
    

    void Start()
    {
        // ps = GetComponent<ParticleSystem>();
    }

    void Update() {
        if(fireTimer > 0) {
            fireTimer -= Time.deltaTime;
        }
        if(Input.GetKeyDown("b")) {
            Fire();
        }
        if(Input.GetKey("g")) {
            GimbalDown();
        }
        if(Input.GetKey("h")) {
            GimbalUp();
        }


    }

    void Fire() {
        // don't fire if we have no cannonball equipped or the delay timer hasn't run out
        if(!inventory.GetHasCategoryEquipped("cannonball") || fireTimer > 0) {
            return;
        }
        // reset the firing delay
        fireTimer = fireDelay;
        // get a cannonball from the pool
        Cannonball newCannonball = cannonball.GetPooledInstance<Cannonball>();
        // set the multiplier of the cannonball based on which is equipped
        newCannonball.multiplier = inventory.GetEquippedOfCategory("cannonball").multiplier;
        Rigidbody rb = newCannonball.GetComponent<Rigidbody>();
        // use ship rb, child rb's calculate velocity wrt the parent, no good
        Rigidbody rbShip = transform.parent.GetComponent<Rigidbody>();
        Vector3 unitBarrelDir = new Vector3(Mathf.Cos(transform.rotation.z), Mathf.Sin(transform.rotation.z), 0f);
        newCannonball.transform.position = transform.position;        
        rb.velocity = rbShip.velocity;
        rb.AddForce(transform.rotation*Vector3.up*barrelSpeed);
        // take cannonball from inventory
        inventory.UseCannonball();
    }

    void GimbalUp() {
        transform.Rotate(0, 0, -gimbalSpeed);
    }

    void GimbalDown() {
        transform.Rotate(0, 0, gimbalSpeed);
    }
}
