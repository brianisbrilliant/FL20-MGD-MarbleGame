using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

		if(objs.Length > 1) {
			Destroy(this.gameObject);
		}

		DontDestroyOnLoad(this.gameObject);
	}
}
