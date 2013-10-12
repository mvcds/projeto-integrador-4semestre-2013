using UnityEngine;
using System.Collections;

public class PlayerM : MonoBehaviour {
	
	public Transform LeftLane;
	public Transform MiddleLane;
	public Transform RightLane;
	public Transform BottomLane;
	public Transform TopLane;
	private float delayTime;
	
	private Position position;
	private Position moving;
	private float delay;
	private float previusDelay;
	private bool diving;
	private bool jumping;
	
	private float divingDelay = 20.0f;
	private float jumpingDelay = 20.0f;
	
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
		diving = false;
		jumping = false;
		delayTime = 1;
		delay = delayTime;
		previusDelay = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (delay >= delayTime){
			diving = false; 
			jumping = false;
			if (Input.GetKey (KeyCode.LeftArrow)) 
				moveToLeft();
		
			if (Input.GetKey (KeyCode.RightArrow)) 
				moveToRight();
			
			if (Input.GetKey (KeyCode.DownArrow)) 
				dive();
			
			if (Input.GetKey (KeyCode.UpArrow)) 
				jump();
			
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
		delayTime = 1;
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
		delayTime = 1;
	}
	
	private void dive(){
		delay = 0;
		previusDelay = Time.time;
		diving = true;
		delayTime = divingDelay;
	}
	
	private void jump(){
		delay = 0;
		previusDelay = Time.time;
		jumping = true;
		delayTime = jumpingDelay;
	}
	
	private void playAnimation(){
		if (jumping == true){
			if (delay < jumpingDelay * 0.3){
				transform.position = new Vector3(transform.position.x, TopLane.position.y * (delay / (jumpingDelay * 0.3f)), 0);
				
			}else if (delay < jumpingDelay * 0.7) { 
				// Tempo parado
				
			} else {
				transform.position = new Vector3(transform.position.x, transform.position.y * (1-((delay - (jumpingDelay * 0.7f)) / (jumpingDelay * 0.3f))), 0);
			}
		} else if (diving == true){
			if (delay < divingDelay * 0.3){
				transform.position = new Vector3(transform.position.x, BottomLane.position.y * (delay / (divingDelay * 0.3f)), 0);
				
			}else if (delay < divingDelay * 0.7) { 
				// Tempo parado
				
			} else {
				transform.position = new Vector3(transform.position.x, transform.position.y * (1-((delay - (divingDelay * 0.7f)) / (divingDelay * 0.3f))), 0);
			}
		} else {
			if (moving == Position.Left)
				transform.position = new Vector3(LeftLane.position.x * delay, transform.position.y, 0);
				
			if (moving == Position.Middle)
				transform.position = new Vector3(transform.position.x * (1.0f - delay), transform.position.y, 0); 
		
			if (moving == Position.Right)
				transform.position = new Vector3(RightLane.position.x * delay, transform.position.y, 0); 
		}
		
		if (delay > delayTime / 2){
			position = moving;
		}
	}
}
