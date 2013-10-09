using UnityEngine;
using System.Collections;

public class ObjSound : MonoBehaviour {
	
	public AudioClip sound;//sound played after collision with powerup
	
	void OnTriggerEnter(Collider other) {
		AudioSource.PlayClipAtPoint(sound, transform.position);
        Destroy(transform.gameObject);
    }
}
