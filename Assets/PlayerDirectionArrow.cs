using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionArrow : MonoBehaviour
{

	PlayerMovement player;

	public Transform arrow;
	Vector3 arrowScale;

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<PlayerMovement>();
		arrowScale = Vector3.one;
    }

    // LateUpdate is called once per frame, after everything in Update()
    void LateUpdate()
    {
        arrow.rotation = Quaternion.LookRotation(player.dir, Vector3.up);
		arrowScale.z = player.dir.magnitude;		
		arrow.localScale = arrowScale;
    }
}
