using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
	[Tooltip("The name of the scene you want to go to.")]
	public string destination;

	void Start() {
		// find the backgroundMusic gameObject and check for new music.
		GameObject.Find("BackgroundMusic").GetComponent<PlayBackgroundMusic>().CheckForNewWorld2();
	}

    void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			other.GetComponent<PlayerMovement>().ResetPlayer();
			GoToNextLevel();
		}
	}

	public void GoToNextLevel(int index = 0) {
		
		// if a number was passed through to this method, go to that level.
		if(index != 0) {
			UnityEngine.SceneManagement.SceneManager.LoadScene(index);
			return;
		}
		// if no index was given, and no destination was specified, go to main menu.
		else if(destination == "") {
			destination = "MainMenu";
		}
		UnityEngine.SceneManagement.SceneManager.LoadScene(destination);

	}
}
