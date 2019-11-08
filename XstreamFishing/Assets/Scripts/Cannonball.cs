using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cannonball : PooledObject {


	void OnTriggerEnter (Collider enteredCollider) {
		if (enteredCollider.CompareTag("destroyZone")) {
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.velocity = Vector3.zero;
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