using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// add coin pickup sound
// add scoretext
// add coin material
// add jump powerup

public class PlayerMovement : MonoBehaviour
{

	public bool phoneIsConnected = false;

	[Header("Movement")]
	public float jumpForce = 5;

	[Header("Audio Clips")]
	public AudioClip calibrateClip;
	public AudioClip jumpClip;
	public AudioClip coinClip;

	[Header("Score UI")]
	public TextMeshProUGUI scoreText;

	[HideInInspector]
	public Vector3 dir, startPosition, calibratedDir;

	// private variables
	Rigidbody rb;
	AudioSource aud;
	bool isGrounded = true;
	bool canJump = false;

	int score = 0;
	int coinScore = 250;

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
		if(!phoneIsConnected && Input.GetKeyDown(KeyCode.Space)) Jump();
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

	public void Jump() {
		if(isGrounded && canJump) {
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			aud.PlayOneShot(jumpClip);
		}
	}

	void OnCollisionEnter() { isGrounded = true; }
	void OnCollisionExit() { isGrounded = false; }



	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Coin")) {
			score += coinScore;
			scoreText.text = "Score = " + score;
			aud.PlayOneShot(coinClip);
			Destroy(other.gameObject);
		}
		if(other.gameObject.name == "Jump Pickup") {
			canJump = true;
			aud.PlayOneShot(jumpClip);
			Destroy(other.gameObject);
		}
	}

}








/*
	Calibrate Tilt function - DONE
	Jump function - DONE
	Force Platforms
	score and pickups
	Player don't destroy on load - DONE

*/
