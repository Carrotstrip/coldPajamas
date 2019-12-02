using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cannonball : PooledObject
{

    public int multiplier;
    public Inventory firerInventory;

    void OnCollisionEnter(Collision collision)
    {
        Collider enteredCollider = collision.collider;

        Debug.Log(enteredCollider.tag);
        if (enteredCollider.CompareTag("destroyZone"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
        }
        if (enteredCollider.CompareTag("Player"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            Inventory otherInventory = enteredCollider.gameObject.GetComponentInParent(typeof(Inventory)) as Inventory;
            PlayerToastManager other_ptm = enteredCollider.gameObject.transform.parent.gameObject.GetComponentInParent(typeof(PlayerToastManager)) as PlayerToastManager;
            PlayerToastManager this_ptm = firerInventory.gameObject.GetComponentInParent(typeof(PlayerToastManager)) as PlayerToastManager;
            // PlayerManager this_player_manager = firerInventory.gameObject.GetComponentInParent(typeof(PlayerManager)) as PlayerManager;
            // int this_index = this_player_manager.index;
            // PlayerManager other_player_manager = enteredCollider.gameObject.transform.parent.gameObject.GetComponentInParent(typeof(PlayerManager)) as PlayerManager;
            // int other_index = other_player_manager.index;
            Debug.Log("in cannonball, ptm: " + other_ptm + " " + this_ptm);
            // Debug.Log("this index " + this_index + " other index " + other_index);
            // PlayerToastManager ptm = enteredCollider.gameObject.GetComponent
            if (otherInventory != null)
            {
                // otherInventory.DropItem();
                int numFishDropped = otherInventory.DropFish(multiplier);
                if (numFishDropped > 0)
                {
                    this_ptm.OverwriteToast("Stole " + numFishDropped + " Finjamins from player");
                    other_ptm.OverwriteToast("A player stole " + numFishDropped + " Finjamins from you!");
                    firerInventory.GainFish(numFishDropped);
                }
                else
                {
                    this_ptm.OverwriteToast("Player had no Finjamins to steal!");
                }
            }
        }
        ReturnToPool();
    }
}