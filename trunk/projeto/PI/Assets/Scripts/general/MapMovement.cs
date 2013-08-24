using UnityEngine;
using System.Collections;

public class MapMovement : MonoBehaviour {

	public GameObject[] Blocks;
	
	private GameObject[] Objs;
	private float delay;
	private float randomDelayTime;
	
	// Use this for initialization
	void Start () {
		Objs = new GameObject[4];
		delay = Time.time;
		randomDelayTime = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
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
	}
		
	private int getRandomLane(){
		int rand = (int)Random.Range(0, 3);
		switch (rand){
			case 0: return -5; break;
			case 2: return 5; break;
		}
		return 0;
	}		
}
