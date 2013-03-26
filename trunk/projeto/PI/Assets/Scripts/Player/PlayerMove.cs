using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove: MonoBehaviour
{

	//TODO: Require a character controller to be attached to the same game object
	public AnimationClip    idleAnimation,
							walkAnimation,
							runAnimation,
							jumpPoseAnimation;
							
	public float  walkMaxAnimationSpeed = 0.75f,
				  trotMaxAnimationSpeed = 1f,
				  runMaxAnimationSpeed = 1f,
				  jumpAnimationSpeed = 1.15f,
				  landAnimationSpeed = 1f;
				  
	private Animation _animation;
	//TODO: private var csScript : LoadNextLevel;  
	
	enum CharacterState {
		Idle = 0,
		Walking,
		Trotting,
		Running,
		Jumping	
	}
	
	private CharacterState _characterState;
	
	float walkSpeed = 2f,
		  trotSpeed = 4f,
		  runSpeed = 6f,
		  inAirControlAcceleration = 3f,
		  jumpHeight = 0.5f,
		  gravity = 20f,
		  speedSmoothing = 10f,
		  rotateSpeed = 500f,
		  trotAfterSeconds = 3f; 
		  
	bool canJump = false;
	
	private float jumpRepeatTime = 0.05f,
				  jumpTimeout = 0.15f,
				  groundedTimeout = 0.25f,
				  lockCameraTimer = 0f,
				  verticalSpeed = 0f,
				  moveSpeed = 0f;
   	private Vector3 moveDirection = Vector3.zero;
				  
	private CollisionFlags collisionFlags;//TODO: understand
	
	private bool jumping = false,
				 jumpingReachedApex = false,
				 movingBack = false,
				 isMoving = false;
				 
	private float walkTimeStart = 0.0f,
				  lastJumpButtonTime = -10.0f,
				  lastJumpTime = -1.0f,
				  lastJumpStartHeight = 0.0f,
				  lastGroundedTime = 0.0f;
	
	private Vector3 inAirVelocity = Vector3.zero;
				 
	private bool isControllable =  true;
	
	void Awake()
	{	
		moveDirection = transform.TransformDirection(Vector3.forward);
		
		_animation = (Animation) GetComponent("Animation");
		/*
		if(!_animation)
			Debug.Log("The character you would like to control doesn't have animations. Moving her might look weird.");
		if(!idleAnimation) {
			_animation = null;
			Debug.Log("No idle animation found. Turning off animations.");
		}
		if(!walkAnimation) {
			_animation = null;
			Debug.Log("No walk animation found. Turning off animations.");
		}
		if(!runAnimation) {
			_animation = null;
			Debug.Log("No run animation found. Turning off animations.");
		}
		if(!jumpPoseAnimation && canJump) {
			_animation = null;
			Debug.Log("No jump animation found and the character has canJump enabled. Turning off animations.");
		}	
		//*/
	}
	
	void UpdateSmoothedMovementDirection ()
	{
		Transform cameraTransform = Camera.main.transform;
		bool grounded = IsGrounded();
		
		//TODO: use the right type
		Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
		forward.y = 0;
		forward = forward.normalized;	
		
		Vector3 right = new Vector3(forward.z, 0, -forward.x);
		float v = Input.GetAxisRaw("Vertical");
		float h = Input.GetAxisRaw("Horizontal");
		
		if (v < -0.2)
			movingBack = true;
		else
			movingBack = false;
	
		bool wasMoving = isMoving;
		isMoving = Mathf.Abs (h) > 0.1 || Mathf.Abs (v) > 0.1;
	
		var targetDirection = h * right + v * forward;//TODO:?
		
		//csScript = GetComponent("LoadNextLevel");//TODO:?
		
		if (grounded && !LoadNextLevel.StageCleared)
		{
			// Lock camera for short period when transitioning moving & standing still
			lockCameraTimer += Time.deltaTime;
			if (isMoving != wasMoving)
				lockCameraTimer = 0.0f;
	
			// We store speed and direction seperately,
			// so that when the character stands still we still have a valid forward direction
			// moveDirection is always normalized, and we only update it if there is user input.
			if (targetDirection != Vector3.zero)
			{			
				// If we are really slow, just snap to the target direction
				if (moveSpeed < walkSpeed * 0.9 && grounded)
				{
					moveDirection = targetDirection.normalized;
				}
				// Otherwise smoothly turn towards it
				else
				{
					moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000);
					
					moveDirection = moveDirection.normalized;
				}
			}
			
			// Smooth the speed based on the current target direction
			var curSmooth = speedSmoothing * Time.deltaTime;
			
			// Choose target speed
			//* We want to support analog input but make sure you cant walk faster diagonally than just forward or sideways
			float targetSpeed = Mathf.Min(targetDirection.magnitude, 1.0f);
		
			_characterState = CharacterState.Idle;
			
			// Pick speed modifier
			if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
			{
				targetSpeed *= runSpeed;
				_characterState = CharacterState.Running;
			}
			else if (Time.time - trotAfterSeconds > walkTimeStart)
			{
				targetSpeed *= trotSpeed;
				_characterState = CharacterState.Trotting;
			}
			else
			{
				targetSpeed *= walkSpeed;
				_characterState = CharacterState.Walking;
			}
			
			moveSpeed = Mathf.Lerp(moveSpeed, targetSpeed, curSmooth);
			
			// Reset walk time start when we slow down
			if (moveSpeed < walkSpeed * 0.3)
				walkTimeStart = Time.time;
		}
		// In air controls
		else
		{
			// Lock camera while in air
			if (jumping)
				lockCameraTimer = 0.0f;
	
			if (isMoving)
				inAirVelocity += targetDirection.normalized * Time.deltaTime * inAirControlAcceleration;
				
			if (LoadNextLevel.StageCleared)
				moveSpeed = 0f;
		}
	}
	
	void ApplyGravity()
	{
		if (isControllable)
		{
			var jumpButton = Input.GetButton("Jump");
			
			if (jumping && !jumpingReachedApex && verticalSpeed <= 0.0)
			{
				jumpingReachedApex = true;
				SendMessage("DidJumpReachApex", SendMessageOptions.DontRequireReceiver);			
			}
		
			if (IsGrounded ())
				verticalSpeed = 0.0f;
			else
				verticalSpeed -= gravity * Time.deltaTime;
		}
	}
	
	float CalculateJumpVerticalSpeed (float targetJumpHeight)
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * targetJumpHeight * gravity);
	}
	
	void DidJump ()
	{
		jumping = true;
		jumpingReachedApex = false;
		lastJumpTime = Time.time;
		lastJumpStartHeight = transform.position.y;
		lastJumpButtonTime = -10;
		
		_characterState = CharacterState.Jumping;
	}
	
	void Update()
	{
		if (!isControllable)
		{
			// kill all inputs if not controllable.
			Input.ResetInputAxes();
		}
		
		if (Input.GetButtonDown ("Jump"))
		{
			lastJumpButtonTime = Time.time;
		}
		
		UpdateSmoothedMovementDirection();
		
		// Apply gravity
		// - extra power jump modifies gravity
		// - controlledDescent mode modifies gravity
		ApplyGravity ();
	
		// Apply jumping logic
		//TODO: use it ApplyJumping ();
		
		// Calculate actual motion
		Vector3 movement = moveDirection * moveSpeed + new Vector3(0,verticalSpeed,0) + inAirVelocity;
		movement *= Time.deltaTime;
		
		// Move the controller
		CharacterController controller = (CharacterController) GetComponent("CharacterController");
		collisionFlags = controller.Move(movement);
		
		// ANIMATION sector
		if(_animation) {
			if(_characterState == CharacterState.Jumping) 
			{
				if(!jumpingReachedApex) {
					_animation[jumpPoseAnimation.name].speed = jumpAnimationSpeed;
					_animation[jumpPoseAnimation.name].wrapMode = WrapMode.ClampForever;
					_animation.CrossFade(jumpPoseAnimation.name);
				} else {
					_animation[jumpPoseAnimation.name].speed = -landAnimationSpeed;
					_animation[jumpPoseAnimation.name].wrapMode = WrapMode.ClampForever;
					_animation.CrossFade(jumpPoseAnimation.name);				
				}
			} 
			else 
			{
				if(controller.velocity.sqrMagnitude < 0.1) {
					_animation.CrossFade(idleAnimation.name);
				}
				else 
				{
					if(_characterState == CharacterState.Running) {
						_animation[runAnimation.name].speed = Mathf.Clamp(controller.velocity.magnitude, 0.0f, runMaxAnimationSpeed);
						_animation.CrossFade(runAnimation.name);	
					}
					else if(_characterState == CharacterState.Trotting) {
						_animation[walkAnimation.name].speed = Mathf.Clamp(controller.velocity.magnitude, 0.0f, trotMaxAnimationSpeed);
						_animation.CrossFade(walkAnimation.name);	
					}
					else if(_characterState == CharacterState.Walking) {
						_animation[walkAnimation.name].speed = Mathf.Clamp(controller.velocity.magnitude, 0.0f, walkMaxAnimationSpeed);
						_animation.CrossFade(walkAnimation.name);	
					}
					
				}
			}
		}
		// ANIMATION sector
		
		// Set rotation to the move direction
		if (IsGrounded())
		{
			
			transform.rotation = Quaternion.LookRotation(moveDirection);
				
		}	
		else
		{
			var xzMove = movement;
			xzMove.y = 0;
			if (xzMove.sqrMagnitude > 0.001)
			{
				transform.rotation = Quaternion.LookRotation(xzMove);
			}
		}	
		
		// We are in jump mode but just became grounded
		if (IsGrounded())
		{
			lastGroundedTime = Time.time;
			inAirVelocity = Vector3.zero;
			if (jumping)
			{
				jumping = false;
				SendMessage("DidLand", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
	
	//TODO: use the right return type
	public void OnControllerColliderHit (ControllerColliderHit hit)
	{
	//	Debug.DrawRay(hit.point, hit.normal);
		if (hit.moveDirection.y > 0.01) 
			return;
	}
	
	public float GetSpeed () {
		return moveSpeed;
	}
	
	public bool IsJumping () {
		return jumping;
	}
	
	public bool IsGrounded () {
		return (collisionFlags & CollisionFlags.CollidedBelow) != 0;
	}
	
	public Vector3 GetDirection () {
		return moveDirection;
	}
	
	public bool IsMovingBackwards () {
		return movingBack;
	}
	
	public float GetLockCameraTimer () 
	{
		return lockCameraTimer;
	}
	
	public bool IsMoving ()
	{
		return Mathf.Abs(Input.GetAxisRaw("Vertical")) + Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5;
	}
	
	public bool HasJumpReachedApex ()
	{
		return jumpingReachedApex;
	}
	
	public bool IsGroundedWithTimeout ()
	{
		return lastGroundedTime + groundedTimeout > Time.time;
	}
	
	public void Reset ()
	{
		gameObject.tag = "Player";
	}
	
}