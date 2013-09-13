using UnityEngine;
using System.Collections;

public class ZigZagObjMovement : MonoBehaviour {
	
	public float speed;
	bool direction;
	
	// Use this for initialization
	void Start () {
		direction = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia){
			transform.Translate((-Vector3.forward * Time.deltaTime * MainScript.gameVelocity) / MainScript.floatSpeed);
		} else {
			transform.Translate(-Vector3.forward * Time.deltaTime * MainScript.gameVelocity);
		}
		
		if (transform.position.x > 4)
			direction = true;
		if (transform.position.x < -4) 
			direction = false;
		
		if (direction)
			transform.Translate(new Vector3(-speed, 0, 0));
		else 
			transform.Translate(new Vector3(speed, 0, 0));
				
		if (transform.position.z < -10){
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider other) {
        Destroy(transform.gameObject);
		PlayerStatus.gotHit();
    }
}
