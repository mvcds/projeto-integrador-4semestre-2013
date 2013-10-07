using UnityEngine;
using System.Collections;
using System;

public class PowerUp : MonoBehaviour {
	
	public int powerUpID;
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia){
			transform.Translate((-Vector3.forward * Time.deltaTime * MainScript.gameVelocity) / MainScript.floatSpeed);
		} else {
			transform.Translate(-Vector3.forward * Time.deltaTime * MainScript.gameVelocity);
		}
		
		if (transform.position.z < -10){
			Destroy(gameObject);
		}
	}
	
	 void OnTriggerEnter(Collider other) {
		Destroy(transform.gameObject);
		PlayerStatus.gotPowerUp(powerUpID);
    }
}
