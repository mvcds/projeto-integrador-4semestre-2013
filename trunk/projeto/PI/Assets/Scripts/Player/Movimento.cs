using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {
	
	public float speed;
	public float turnSpeed;
	public int jumpHeight;
	public AudioSource pause;
	private float inputSpeed;
	private float inputTurnSpeed;
		
	// Use this for initialization
	void Start () {
		//print (transform.forward);
	}
	
	// Update is called once per frame
	void Update () {
		if (!GamePlay.Instance.canMove)
			return;
		
		if (!GamePlay.Instance.isPaused) {
			// Updates
			GuardaChuva.verificaGC();
			
			inputTurnSpeed = Input.GetAxis("Horizontal");
			inputSpeed = Input.GetAxis("Vertical");
			
			transform.Translate(Vector3.forward * inputSpeed * speed * Time.deltaTime, Space.Self);
			transform.Rotate(new Vector3(0, inputTurnSpeed * turnSpeed * speed * Time.deltaTime,0));
			
			// Pulo
			if (Input.GetKeyDown(KeyCode.Space) &&  Physics.Raycast(transform.position, -Vector3.up, 1)) {
				rigidbody.AddForce(Vector3.up * jumpHeight);
			}
			
			// Guarda-Chuva
			if (Input.GetKeyDown(KeyCode.E)) {
				GuardaChuva.abrirGC();
			}
		}
		
		// Pause
		if (Input.GetKeyDown(KeyCode.Return)) {
			GamePlay.Instance.Pause(!GameObject.Find("Background Camera").camera.enabled);
			GameObject.Find("Background Camera").camera.enabled = GamePlay.Instance.isPaused;
			pause.Play();
			// Pauser Jogo Inteiro
		}
	}
}
