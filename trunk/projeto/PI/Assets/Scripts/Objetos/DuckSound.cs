using UnityEngine;
using System.Collections;
using System;

public class DuckSound : MonoBehaviour {
	
	public AudioClip quack;
	public static float count = 1;
	public DateTime time;
	
	void Start()
	{
		//source = (AudioSource) GetComponent(typeof(AudioSource));
	}
	
	void Update()
	{
		TimeSpan t = DateTime.Now - time;
		if(t.TotalSeconds > 5)
			count = 1;
		
	}
	
	void OnTriggerEnter(Collider other) {
		//source.pitch = count;
		AudioSource.PlayClipAtPoint(quack, transform.position);
		count += 2f;
		time = DateTime.Now;
        Destroy(transform.gameObject);
    }
}
