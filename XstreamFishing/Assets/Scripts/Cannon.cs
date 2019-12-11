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
    public bool gimbalingUp;
    public bool gimbalingDown;
    public AudioClip cannonSound;
    public PlayerManager playerManager;
    

    void Start()
    {
        // ps = GetComponent<ParticleSystem>();
    }

    void Update() {
        if(fireTimer > 0) {
            fireTimer -= Time.deltaTime;
        }
        if(gimbalingUp) {
            GimbalUp();
        }
        if(gimbalingDown) {
            GimbalDown();
        }
    }


    public void Fire() {
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
        newCannonball.firerInventory = inventory;
        Rigidbody rb = newCannonball.GetComponent<Rigidbody>();
        // use ship rb, child rb's calculate velocity wrt the parent, no good
        Rigidbody rbShip = transform.parent.GetComponent<Rigidbody>();
        Vector3 unitBarrelDir = new Vector3(Mathf.Cos(transform.rotation.z), Mathf.Sin(transform.rotation.z), 0f);
        newCannonball.transform.position = transform.position;
        rb.velocity = rbShip.velocity;
        rb.AddForce(transform.rotation*Vector3.up*barrelSpeed);
        AudioManager.instance.PlaySoundEffect(cannonSound, playerManager.index);
        // take cannonball from inventory
        inventory.UseCannonball();
    }

    public void GimbalUp() {
        transform.Rotate(-gimbalSpeed, 0, 0);
    }

    public void GimbalDown() {
        transform.Rotate(gimbalSpeed, 0, 0);
    }
}
