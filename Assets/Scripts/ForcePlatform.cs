using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlatform : MonoBehaviour
{
	public float force = 10;
	[Tooltip("Would you like this platform to be destroyed when it is used?")]
	public bool destroyAfterUse = false;

	Vector3 dir;

	void Start() {
		dir = this.transform.up;
	}

    void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			Rigidbody rb = other.GetComponent<Rigidbody>();
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			// don't use Relative force, we are calculating 
			// "relative UP" based on Dir during start
			rb.AddForce(dir * force, ForceMode.Impulse);
			Debug.Log("Dir: " + dir);
			if(destroyAfterUse) {
				Destroy(this.gameObject, 0.25f);
			}
		}
	}
}
