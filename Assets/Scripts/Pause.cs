using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
	bool isPaused = false;

	public GameObject pausePanel;

	void Start() {
		if(pausePanel == null){
			Debug.Log("Looking for PausePanel...");
			pausePanel = GameObject.Find("PauseMenu");
		}
		pausePanel.SetActive(false);
		Debug.Log("isPaused = " + isPaused);
	}

	public void PauseGame() {

		isPaused = !isPaused;		// flip the boolean

		Debug.Log("The PauseGame() method has been called. isPaused: " + isPaused);
		if(isPaused) {
			pausePanel.SetActive(true);			// show the pause menu
			Time.timeScale = 0;					// freeze time
		} else {
			pausePanel.SetActive(false);		// hide the pause menu
			Time.timeScale = 1;					// set time back to normal
		}

		
	}
}
