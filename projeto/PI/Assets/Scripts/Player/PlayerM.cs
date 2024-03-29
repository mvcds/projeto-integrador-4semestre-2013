using UnityEngine;
using System.Collections;
using System;

public class PlayerM : MonoBehaviour {
	
	public enum Position {
		Left = -1,
		Middle,
		Right
	}
	
	public Transform LeftLane;
	public Transform MiddleLane;
	public Transform RightLane;
	public Transform BottomLane;
	public Transform TopLane;
	
	public float divingDelay;
	public float jumpingDelay;
	public float movingDelay;
	
	public float empuxo;
	public float jumpHeight;
	public float diveForce;
	public float atritoAgua;
	private float nivelAgua;
	private float resistencia;
	
	private float delayTime;
	private float delay;
	private float verticalDelay;
	private float verticalDelayTime;
	//private float divingDelay;
	
	private Position position;
	private Position moving;
	private int goingMiddleFromRight;
	
	private bool diving;
	private bool jumping;
	private float distance;
	private DateTime dt = DateTime.Now;
    private bool startedTime = false;
	
	public AudioSelecter aud;
	
	// Use this for initialization
	void Start () {
		position = Position.Middle;
		moving = Position.Middle;
		
		diving = false;
		jumping = false;
		
		delay = delayTime;
		delayTime = movingDelay;
		
		verticalDelay = verticalDelayTime;
		verticalDelayTime = movingDelay;
		divingDelay = 0;
	}

    void FixedUpdate()
    {
        boiar();
        
    }

	// Update is called once per frame
    void Update()
    {
		
		folego();
		
        if (!Director.Instance.isRunning || PlayerStatus.hasGameOverHappend)
            return;
        else if (!startedTime)
        {
            dt = DateTime.Now;
            startedTime = true;
        }

		TimeSpan span = DateTime.Now - dt;
		if (span.TotalSeconds > 1){
			if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia){
				distance += ((MainScript.gameVelocity / 1.666f) / 10) / MainScript.floatSpeed;
			} else {
				distance += ((MainScript.gameVelocity / 1.666f) / 10);
			}
			dt = DateTime.Now;
            Director.Instance.GameRank.Distance = distance;
		}
		
		divingDelay += Time.deltaTime;
				
				if (Input.GetKeyUp (KeyCode.DownArrow)){ 
					diving = false;
					empuxo = 80;
					if (divingDelay > 1.0f)
					divingDelay = 0;
				}
		
		if (delay >= delayTime){
			//diving = false; 
			jumping = false;
			if (Input.GetKey (KeyCode.LeftArrow)) 
				MoveTo(Position.Left);

            if (Input.GetKey(KeyCode.RightArrow))
                MoveTo(Position.Right);
			
			
			
			if (verticalDelay >= verticalDelayTime){
				
				if (Input.GetKey (KeyCode.DownArrow)) 
					dive();
				
				if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Capivara && Input.GetKey (KeyCode.UpArrow)) 
					jump();
			} else {
				verticalDelay += Time.deltaTime;
			}
		} else {
			delay += Time.deltaTime;
			playAnimation();
		}
	}
	
	private void boiar(){
		if (!Director.Instance.isPaused){
			rigidbody.drag = 0;
			float resistencia = nivelAgua - transform.position.y;
		
			float empuxoDinamico = Mathf.Clamp(resistencia * empuxo, 0, empuxo);
			float atritoDinamico = Mathf.Clamp(resistencia * atritoAgua, 0, atritoAgua);
		
			rigidbody.AddForce(Vector3.up * empuxoDinamico);
			rigidbody.drag = atritoDinamico;
		}
	}

    private void MoveTo(Position p)
    {
        if (position == p)
            return;

        //*Verificar a diferenša com Rafael
	    if (position == Position.Middle)
        {
            moving = p;
            goingMiddleFromRight = 4;

            if (p == Position.Left)
                goingMiddleFromRight *= -1;
        }
        else
	     //*/
            moving = Position.Middle;

        delay = 0;
        delayTime = movingDelay;
    }
    	
	private void dive(){	
		if (!diving && divingDelay > 1.0f && MainScript.folego >= 1 && PlayerStatus.powerUp != PlayerStatus.PowerUp.Boia && PlayerStatus.powerUp != PlayerStatus.PowerUp.Porta){
			
			rigidbody.AddForce(Vector3.down * diveForce);
			diving = true;
			
			aud.PlayMergulho();
			
			empuxo = 20;
			delay = 0;
			delayTime = 0;//movingDelay;
		
			verticalDelay = 0;
			verticalDelayTime = 0;//divingDelay;
		}	
	}
	
	private void jump(){
		
		rigidbody.AddForce(Vector3.up * jumpHeight);
		jumping = true;
		
		delay = 0;
		delayTime = movingDelay;
		
		verticalDelay = 0;
		verticalDelayTime = jumpingDelay;
	}
	
	private void folego(){
		if (diving){
			if (MainScript.folego > 0){
				MainScript.folego -= Time.deltaTime;
			} else {
				diving = false;
				divingDelay = 0;
				empuxo = 80;
			}
		} else {
			MainScript.folego += Time.deltaTime / 10;
			if (MainScript.folego > MainScript.Maxfolego)
				MainScript.folego = MainScript.Maxfolego;
		}
	}
	
	private void playAnimation(){
		if (jumping != true /*&& diving != true*/){
		
			if (moving == Position.Left)
				transform.position = new Vector3(LeftLane.position.x * (delay / movingDelay), transform.position.y, 0);
				
			if (moving == Position.Middle)
				transform.position = new Vector3(goingMiddleFromRight * (1 - (delay / movingDelay)), transform.position.y, 0); 
			
			if (moving == Position.Right)
				transform.position = new Vector3(RightLane.position.x * (delay / movingDelay), transform.position.y, 0); 
		}
		
		if (delay > delayTime / 2){
			position = moving;
		}
	}
	
}
