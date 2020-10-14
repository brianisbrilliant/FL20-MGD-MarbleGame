using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
	{

	public bool phoneIsConnected = false;

	[Header("Audio Clips")]
	public AudioClip calibrateClip;

	[HideInInspector]
	public Vector3 dir, startPosition, calibratedDir;

	// private variables
	Rigidbody rb;
	AudioSource aud;

	// Start is called before the first frame update
	void Start()
	{
		rb = this.GetComponent<Rigidbody>();
		startPosition = this.transform.position;
		aud = GameObject.Find("AudioSource").GetComponent<AudioSource>();
		CalibrateTilt();
		
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
			dir.x = Input.acceleration.x - calibratedDir.x;
			dir.z = Input.acceleration.y - calibratedDir.z;
		} else {
			dir.x = Input.GetAxis("Horizontal");
			dir.z = Input.GetAxis("Vertical");
		}

		rb.AddForce(dir * 10);
	}

	public void ResetPlayer() {
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		this.transform.position = startPosition;
	}

	public void CalibrateTilt() {
		Debug.Log("Calibrating Tilt");
		calibratedDir.x = Input.acceleration.x;
		calibratedDir.z = Input.acceleration.y;

		aud.PlayOneShot(calibrateClip);
	}
}








/*
	Calibrate Tilt function
	Jump function
	Force Platforms
	score and pickups
	Player don't destroy on load

*/
