using UnityEngine;
using System.Collections;

public class CapivaraAnimation : MonoBehaviour {

	public float speed;
	bool direction;
	
	// Use this for initialization
	void Start ()
	{
		direction = (Random.Range(0, 1) == 0);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        if (!Director.Instance.isRunning)
            return;

		if (transform.position.y > 0.25f)
			direction = true;
		if (transform.position.y < -0.25f) 
			direction = false;
		
		if (direction)
			transform.Translate(new Vector3(0, -speed, 0));
		else 
			transform.Translate(new Vector3(0, speed, 0));			
	}
}
