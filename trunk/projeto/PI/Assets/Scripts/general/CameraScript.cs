using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	
	public Transform player;
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt(player);
		transform.position = new Vector3(player.transform.position.x / 2, transform.position.y, transform.position.z);
	}
}
