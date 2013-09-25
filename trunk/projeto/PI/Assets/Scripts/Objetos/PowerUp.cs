using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	
	public int powerUpID;
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	 void OnTriggerEnter(Collider other) {
		Destroy(transform.gameObject);
		PlayerStatus.gotPowerUp(powerUpID);
    }
}
