using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	
	public int powerUpID;
	public AudioClip sound;//sound played after collision with powerup
	
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
		AudioSource.PlayClipAtPoint(sound, transform.position);
		Destroy(transform.gameObject);
		PlayerStatus.gotPowerUp(powerUpID);
    }
}
