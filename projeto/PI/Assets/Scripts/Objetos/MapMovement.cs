using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectSpawnerByOdd))]
public class MapMovement : MonoBehaviour {

	//public GameObject[] Blocks;
	public GameObject[] DoubleBlocks;
	
	private GameObject[] Objs;
	private float delay;
	private float randomDelayTime;
	private ObjectSpawnerByOdd odd;
	
	// Use this for initialization
	void Start () {
		Objs = new GameObject[6];
		delay = Time.time;
		randomDelayTime = 1;
		odd = (ObjectSpawnerByOdd)GetComponent(typeof(ObjectSpawnerByOdd));//TODO: is there a way to clean it?
	}
	
	void FixedUpdate () {
		
		if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia){
			MainScript.gameVelocity += (Time.deltaTime / (10 * MainScript.floatSpeed));
		} else {
			MainScript.gameVelocity += (Time.deltaTime / 10);
		}
		
		if (Time.time - delay > randomDelayTime){
			//for (int i = 0; i < 6; i++){
			//	if (Objs[i] == null){
					
					GameObject spawn = odd.getObject();
						
					if (spawn == null)
						return;

					if (spawn.CompareTag("DoubleObject")){
						/*Objs[i] = (GameObject)*/ Instantiate(DoubleBlocks[Random.Range (0, DoubleBlocks.Length)],
						new Vector3(getDuoRandomLane(), 0, 40), Quaternion.Euler(new Vector3(0,0,90)));
							
					} else {	
						/*Objs[i] = (GameObject) */Instantiate(spawn,
						new Vector3(getRandomLane(), 0, 40), Quaternion.Euler(new Vector3(0,0,0)));	
					}
					
					delay = Time.time;
			
					if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia){
						randomDelayTime = Random.Range (0.5f, 2) * MainScript.floatSpeed;
					} else {
						randomDelayTime = Random.Range (0.5f, 2);
					}
						
					//break;
				} else {
					//if (Objs[i].transform.position.z < -10){
					//	Destroy(Objs[i]);
					//}
				//}
			//}
		}
	}
		
	private int getRandomLane(){
		int rand = (int)Random.Range(0, 3);
		switch (rand){
			case 0: return -5; break;
			case 2: return 5; break;
		}
		return 0;
	}	
	
	private float getDuoRandomLane(){
		int rand = (int)Random.Range(0, 2);
		switch (rand){
			case 0: return -2.5f; break;
			default: return 2.5f; break;
		}
	}
	
	/*
	 * // Update is called once per frame
	void FixedUpdate () {
		
		GameConstants.gameVelocity = (int)(Time.time / 10) + 5;
		
		if (Time.time - delay > randomDelayTime){
			for (int i = 0; i < 4; i++){
				if (Objs[i] == null){
					Objs[i] = (GameObject) Instantiate(Blocks[Random.Range (0, Blocks.Length)],
					new Vector3(getRandomLane(), 0, 20), Quaternion.Euler(new Vector3(0,0,0)));
					delay = Time.time;
					randomDelayTime = Random.Range (0.5f, 2);	
					break;
				
				} else {
					if (Objs[i].transform.position.z < -10){
						Destroy(Objs[i]);
					}
				}
			}
		}
	}*/
	

	/*
	 * // Update is called once per frame
	void FixedUpdate () {
		
		GameConstants.gameVelocity = (int)(Time.time / 10) + 5;
		
		if (Time.time - delay > randomDelayTime){
			for (int i = 0; i < 4; i++){
				if (Objs[i] == null){
					
					GameObject obj = (GameObject) Blocks[Random.Range (0, Blocks.Length)];
					
					if (Random.Range (0, 5) >= 3){
						randomDuo(obj);
					} else {
						Objs[i] = (GameObject) Instantiate(obj,
						new Vector3(getRandomLane(), 0, 20), Quaternion.Euler(new Vector3(0,0,0)));
					}
					
					delay = Time.time;
					//randomDelayTime = Random.Range (0.5f, 2);
					randomDelayTime = Random.Range (0.3f, 1);
					break;
				
				} else {
					if (Objs[i].transform.position.z < -10){
						Destroy(Objs[i]);
					}
				}
			}
		}
	}*/
	
	
	/*private void randomDuo(GameObject obj){
		int rand = (int)Random.Range(0, 3);
		print ("duo");
		int a = 0;
		int b = 0;
		
		switch (rand){
			case 0: a = -5; b = 0; break;
			case 1: a = 0; b = 5; break;
			case 2: a = -5; b = 5; break;
		}
		
		// FAZER: Melhorar o Index
		Objs[4] = (GameObject) Instantiate(obj,
					new Vector3(a, 0, 20), Quaternion.Euler(new Vector3(0,0,0)));
		
		Objs[5] = (GameObject) Instantiate(obj,
					new Vector3(b, 0, 20), Quaternion.Euler(new Vector3(0,0,0)));
	}*/
}
