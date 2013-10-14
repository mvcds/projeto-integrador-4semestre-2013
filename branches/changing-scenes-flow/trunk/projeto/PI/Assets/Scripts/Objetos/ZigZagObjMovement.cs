using UnityEngine;

//[RequireComponent(typeof(ObjMovement))]
//[RequireComponent(typeof(Obstacle))]
public class ZigZagObjMovement : MonoBehaviour {
	
	public float speed;
	bool direction;
	
	// Use this for initialization
	void Start ()
	{
		direction = (Random.Range(0,1) == 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (!Director.Instance.isRunning)
            return;

		if (transform.position.x > 4)
			direction = true;
		if (transform.position.x < -4) 
			direction = false;
		
		if (direction)
			transform.Translate(new Vector3(-speed, 0, 0));
		else 
			transform.Translate(new Vector3(speed, 0, 0));			
	}
}
