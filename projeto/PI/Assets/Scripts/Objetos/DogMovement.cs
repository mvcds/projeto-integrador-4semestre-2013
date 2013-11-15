using UnityEngine;

//[RequireComponent(typeof(ObjMovement))]
//[RequireComponent(typeof(Obstacle))]
public class DogMovement : MonoBehaviour {
	
	public float speed;
	bool direction;
	
	// Use this for initialization
	void Start ()
	{
		direction = (Random.Range(0,1) == 0);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        if (!Director.Instance.isRunning)
            return;

		if (transform.position.x > 4){
			//direction = true;
			transform.Rotate(new Vector3(0, -180, 0));
		} else
		
		if (transform.position.x < -4) {
			//direction = false;
			transform.Rotate(new Vector3(0, -180, 0));
		}
		
		if (direction)
			transform.Translate(new Vector3(0, 0, -speed));
		else 
			transform.Translate(new Vector3(0, 0, speed));			
	}
}
