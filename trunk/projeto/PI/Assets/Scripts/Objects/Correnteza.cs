using UnityEngine;
using System.Collections;

public class Correnteza : MonoBehaviour {
	public int area = 150;
	public float pullForce = 0.15f;
	public float pullBase = 15.0f;
	private Transform player;
	private Vector3 forca;
	private Vector3 distancia;
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform;
	}
	
	void OnGUI(){
		if (distancia.magnitude < area / 3){
			GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 3, 150, 20), "Aaah!, Correnteza!");
		}
		
	}
	
	void OnTriggerEnter(Collider c){
		if (c.name == "Player" ){
			GamePlay.Instance.death();
		}
	} 
	
	// Update is called once per frame
	void Update () {
		if (GamePlay.Instance.isPaused)
			return;
		
		distancia = transform.position - player.transform.position;
		forca = (distancia / distancia.magnitude) * (((area * 2 - distancia.magnitude) / 5) * pullForce) * Time.deltaTime ;
		if (distancia.magnitude < area){
			player.rigidbody.AddForce(forca);
			player.rigidbody.AddForce(distancia.normalized * pullBase * Time.deltaTime);
			if (distancia.magnitude < area / 10){
				player.rigidbody.AddForce(forca);
			}
		}
	}
}
