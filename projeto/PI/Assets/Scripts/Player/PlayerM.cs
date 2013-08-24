using UnityEngine;
using System.Collections;

public class PlayerM : MonoBehaviour {
	
	public Transform LeftLane;
	public Transform MiddleLane;
	public Transform RightLane;
	public float delayTime = 1.0f;
	
	private Position position;
	private Position moving;
	private float delay;
	private float previusDelay;
	
	public enum Position
	{
		Left = -1,
		Middle,
		Right
	}
	
	// Use this for initialization
	void Start () {
		position = Position.Middle;
		moving = Position.Middle;
		delay = delayTime;
		previusDelay = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		// APAGAR
		//if (position == Position.Left) print ("Left");
		//if (position == Position.Middle) print ("Middle");
		//if (position == Position.Right) print ("Right");
		//
		if (delay >= delayTime){
			 
			if (Input.GetKey (KeyCode.LeftArrow)) 
				moveToLeft();
		
			if (Input.GetKey (KeyCode.RightArrow)) 
				moveToRight();
		} else {
			delay += Time.time - previusDelay;
			playAnimation();
		}
	}
	
	private void moveToLeft(){
		if (position == Position.Left)
			return;
				
		if (position == Position.Middle){
			moving = Position.Left;
		}
		
		if (position == Position.Right){
			moving = Position.Middle;
		}
		delay = 0;
		previusDelay = Time.time;
	}
	
	private void moveToRight(){
		if (position == Position.Right)
			return;
				
		if (position == Position.Middle){
			moving = Position.Right;
		}
		
		if (position == Position.Left){
			moving = Position.Middle;
		}
		delay = 0;
		previusDelay = Time.time;
	}
	
	private void playAnimation(){
		if (moving == Position.Left)
			transform.position = new Vector3(LeftLane.position.x * delay, 0, 0);
				
		if (moving == Position.Middle)
			transform.position = new Vector3(transform.position.x * (1.0f - delay), 0, 0); 
		
		if (moving == Position.Right)
			transform.position = new Vector3(RightLane.position.x * delay, 0, 0); 
		
		if (delay > delayTime / 2){
			position = moving;
		}
	}
}
