using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cannonball : PooledObject {

	void OnTriggerEnter (Collider enteredCollider) {
		if (enteredCollider.CompareTag("destroyZone")) {
			ReturnToPool();
		}
	}
}