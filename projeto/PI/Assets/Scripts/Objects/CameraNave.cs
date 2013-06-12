using UnityEngine;
using System.Collections;

public class CameraNave : MonoBehaviour {
	
	public Transform player;
	public float vel;
	public float distance;
	public float height;
	private bool sentido;
	private int altura = 1;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 lookTo = player.position - transform.position;
		Vector3 moveTo = player.position - (player.forward * distance) - transform.position;
				
		transform.forward = lookTo;
		transform.position += moveTo * vel + Vector3.up * height;
		
		if (sentido){
			    Vector3 position = transform.position;
    			position.y += 0.005f;
    			transform.position = position;
			altura++;
			
		} else {
			Vector3 position = transform.position;
    			position.y -= 0.005f;
    			transform.position = position;
			altura--;
		}
		if (altura > 10 || altura < 0){
			sentido = !sentido;
		}
	}
}
