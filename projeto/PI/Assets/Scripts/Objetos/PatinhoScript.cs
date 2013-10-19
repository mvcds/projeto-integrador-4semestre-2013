using UnityEngine;
using System.Collections;
using System;

public class PatinhoScript : MonoBehaviour {
	
	private Boolean hit;
	
	// Use this for initialization
	void Start () {
		hit = false;
	}
		
	 void OnTriggerEnter(Collider other) {
		if (!hit){
			Destroy(transform.gameObject);
			//MainScript.ducks++;
            Director.Instance.GameRank.AddDuck();
			hit = true;
		}
    }
}
