using UnityEngine;
using System.Collections;
//
// NÃO ESTÁ MAIS SENDO UTILIZADO
//
[RequireComponent(typeof(ObjectSpawnerByOdd))]
public class MapMovement : MonoBehaviour {

	public GameObject[] DoubleBlocks;
	
	private GameObject[] Objs;
	private float delay;
	private float randomDelayTime;
	private ObjectSpawnerByOdd odd;
	
	private float leftBlock;
	private float middleBlock;
	private float rightBlock;
	private float blockTime = 3;
	
	// Use this for initialization
	void Start () {
		Objs = new GameObject[6];
		delay = Time.time;
		randomDelayTime = 1;
		odd = (ObjectSpawnerByOdd)GetComponent(typeof(ObjectSpawnerByOdd));//TODO: is there a way to clean it?
	}
	
	//TODO: tem como jogar esse movimento como os outros?
	void FixedUpdate () {
		
		if (!Director.Instance.isRunning)
			return;
		
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
						if (leftBlock <= 0 && middleBlock <= 0 && rightBlock <=0){
							/*Objs[i] = (GameObject)*/ Instantiate(DoubleBlocks[Random.Range (0, DoubleBlocks.Length)],
							new Vector3(getDuoRandomLane(), 0, 40), Quaternion.Euler(new Vector3(0,0,90)));
						}	
					} else if (spawn.CompareTag("Block")) {
						if ((leftBlock <= 0 && middleBlock <=0) ||
							(middleBlock <= 0 && rightBlock <=0) ||
							(leftBlock <= 0 && rightBlock <=0))
						Instantiate(spawn,
						new Vector3(getAndBlockRandomLane(), 0, 45), Quaternion.Euler(new Vector3(0,0,0)));	
					} else {
						if (leftBlock <= 0 || middleBlock <= 0 || rightBlock <=  0){
						/*Objs[i] = (GameObject) */Instantiate(spawn,
						new Vector3(getRandomLane(), 0, 40), Quaternion.Euler(new Vector3(0,0,0)));	
						}	
					}
					
					delay = Time.time;
			
					if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia){
						randomDelayTime = getRandomDelay() * MainScript.floatSpeed;
					} else {
						randomDelayTime = getRandomDelay();
					}
						
					//break;
				} else {
					//if (Objs[i].transform.position.z < -10){
					//	Destroy(Objs[i]);
					//}
				//}
			//}
		}
		
		leftBlock -= Time.deltaTime;
		middleBlock -= Time.deltaTime;
		rightBlock -= Time.deltaTime;
	}
	
	private float getRandomDelay(){
		//print("Random Max Delay: " + (2 - ((MainScript.gameVelocity / 30) * 1.7f)));
		return 5;//Random.Range (0.5f - ((MainScript.gameVelocity / 30) * 0.3f), 2 - ((MainScript.gameVelocity / 30) * 1.7f));
		
	}
	
	private int getRandomLane(){
		int rand = (int)Random.Range(0, 3);
		return 0;
	}
	
	// Para objetos grandes
	private int getAndBlockRandomLane(){
		int rand = (int)Random.Range(0, 3);
		switch (rand){
			case 0:
				if (leftBlock < 0){
					leftBlock = blockTime;
					return -5;
				} else 
					return getAndBlockRandomLane();
			
			case 2:
				if (rightBlock < 0){
					rightBlock = blockTime;
					return 5;
				} else
					return getAndBlockRandomLane();
		}
		
		if (middleBlock < 0){
			middleBlock = blockTime;
			return 0;
		} else
			return getAndBlockRandomLane();
	}	
	
	private float getDuoRandomLane(){
		int rand = (int)Random.Range(0, 2);
		switch (rand){
			case 0: return -2.5f;
			default: return 2.5f; 
		}
	}
}
