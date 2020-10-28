using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour
{
	AudioSource aud;
	public List<AudioClip> songs;
	[Tooltip("What levels are in each world?")]
	public int world1Start, world2Start, world3Start;

    // Start is called before the first frame update
    void Start()
    {
		aud = this.GetComponent<AudioSource>();
        CheckForNewWorld();
    }

	public void CheckForNewWorld() {
		// this should be called by the ChangeLevel script or the PlayerMovement script
		int currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
		switch(currentScene) {
			case 1:
			case 2:
			case 3:
			case 4: aud.clip = songs[0];
					aud.Play();
					break;

			case 5:
			case 6:
			case 7:
			case 8: aud.clip = songs[1];
					aud.Play();
					break;

			case 9:
			case 10:
			case 11:
			case 12: 	aud.clip = songs[2];
						aud.Play();
						break;

			default: Debug.Log("you're in a weird level.");
				break;
		}
	}

	public void CheckForNewWorld2() {
		int currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
		if(currentScene == world1Start) {
			aud.clip = songs[0];
			aud.Play();
		}
		if(currentScene == world2Start) {
			aud.clip = songs[1];
			aud.Play();
		}
		if(currentScene == world3Start) {
			aud.clip = songs[2];
			aud.Play();
		}
	}
}
