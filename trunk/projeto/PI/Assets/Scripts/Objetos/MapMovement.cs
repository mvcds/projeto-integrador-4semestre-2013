using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectSpawnerByOdd))]
public class MapMovement : MonoBehaviour {

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
		
		if (!GameAsApplication.isRunning)
			return;
		
		if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia){
			MainScript.gameVelocity += (Time.deltaTime / (10 * MainScript.floatSpeed));
		} else {
			MainScript.gameVelocity += (Time.deltaTime / 10);
		}
		
		if (Time.time - delay > randomDelayTime)
		{
					
			GameObject spawn = odd.getObject();
				
			if (spawn == null)
				return;

			if (spawn.CompareTag("DoubleObject"))
			{
				Instantiate(DoubleBlocks[Random.Range (0, DoubleBlocks.Length)],
					new Vector3(getDuoRandomLane(), 0, 40), Quaternion.Euler(new Vector3(0,0,90)));
					
			} else {	
				Instantiate(spawn, new Vector3(getRandomLane(), 0, 40), Quaternion.Euler(new Vector3(0,0,0)));	
			}
			
			delay = Time.time;
	
			if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia){
				randomDelayTime = Random.Range (0.5f, 2) * MainScript.floatSpeed;
			} else {
				randomDelayTime = Random.Range (0.5f, 2);
			}			
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
}
