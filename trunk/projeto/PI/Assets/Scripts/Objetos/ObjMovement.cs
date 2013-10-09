using UnityEngine;
using System.Collections;
using System;

public class ObjMovement : MonoBehaviour {
	
	private float destroyAt = 5;
	
	// Update is called once per frame
	void Update () 
	{		
		if (!GameController.isRunning)
			return;
		
		if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia){
			transform.Translate((-Vector3.forward * Time.deltaTime * MainScript.gameVelocity) / MainScript.floatSpeed);
		} else {
			transform.Translate(-Vector3.forward * Time.deltaTime * MainScript.gameVelocity);
		}
		
		if (transform.position.z < -destroyAt){
			Destroy(gameObject);
		}
	}
}
