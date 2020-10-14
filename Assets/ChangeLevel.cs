using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
	[Tooltip("The name of the scene you want to go to.")]
	public string destination;

    void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			other.GetComponent<PlayerMovement>().ResetPlayer();
			GoToNextLevel();
		}
	}

	public void GoToNextLevel() {
		if(destination == "") destination = "MainMenu";
		UnityEngine.SceneManagement.SceneManager.LoadScene(destination);

	}
}
