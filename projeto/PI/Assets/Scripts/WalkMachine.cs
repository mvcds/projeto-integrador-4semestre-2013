using UnityEngine;
using System.Collections;

public class WalkMachine : MonoBehaviour {
	
	public Animation anim;
	float speed;
	float turn;
	bool queued;
		
	void Start () {
	
	}
	
	void Update () {
		playAnimation();
	}
	
	void playAnimation(){
		speed = Input.GetAxis("Vertical");
		turn = Input.GetAxis("Horizontal");
		
		if (speed < -0.5f)
			speed = -0.5f;
		
		if (queued){
			anim.CrossFadeQueued("idle");
		} else {
			anim.CrossFade("idle");	
		}	
			
		if (speed < -0.1f || speed > 0.1f){
			
			if (speed > 0.7f){
				anim["run"].speed = speed;
				anim.CrossFade("run");
			} else {
				anim["walk"].speed = speed;
				anim.CrossFade("walk");
			}
			queued = false;
		}
				
		if (Input.GetKeyDown (KeyCode.X)){
			anim.CrossFade("attack");
			queued = true;
		}
		if (Input.GetKeyDown (KeyCode.C)){
			anim.CrossFade("victory");
		}
		
		
	}
	
	void FixedUpdate(){
		transform.Translate(Vector3.forward * speed * 0.10f);
		transform.RotateAround(Vector3.up, turn * 0.05f);
	}
}
