using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
	{

	public bool phoneIsConnected = false;

	[HideInInspector]
	public Vector3 dir, startPosition;
	Rigidbody rb;

	// Start is called before the first frame update
	void Start()
	{
		rb = this.GetComponent<Rigidbody>();
		startPosition = this.transform.position;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.R)) ResetPlayer();
		if(this.transform.position.y < -2) ResetPlayer();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		dir = Vector3.zero;
        if(phoneIsConnected) {
			dir.x = Input.acceleration.x;
			dir.z = Input.acceleration.y;
		} else {
			dir.x = Input.GetAxis("Horizontal");
			dir.z = Input.GetAxis("Vertical");
		}

		rb.AddForce(dir * 10);
	}

	public void ResetPlayer() {
		rb.velocity = Vector3.zero;
		this.transform.position = startPosition;
	}
}
