using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cannonball : PooledObject {

	public int multiplier;
	public Inventory firerInventory;

	void Start() {
	}

	void OnTriggerEnter (Collider enteredCollider) {
		if (enteredCollider.CompareTag("destroyZone")) {
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.velocity = Vector3.zero;
			ReturnToPool();
		}
		if(enteredCollider.CompareTag("Player")) {
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.velocity = Vector3.zero;
			Inventory otherInventory = enteredCollider.gameObject.GetComponent<Inventory>();
			if(otherInventory != null) {
				otherInventory.DropItem();
				int numFishDropped = otherInventory.DropFish(multiplier);
				firerInventory.GainFish(numFishDropped);
			}
			ReturnToPool();
		}
	}

	void OnCollisionEnter(Collision collision) {
		Collider collider = collision.collider;
		if(collider.CompareTag("Player")) {
			Inventory inv = collision.transform.gameObject.GetComponent<Inventory>();
			Debug.Log("lose stuff");
		}
	}
}