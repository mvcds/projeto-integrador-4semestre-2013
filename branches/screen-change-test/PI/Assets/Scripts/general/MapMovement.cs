using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectSpawnerByOdd))]
public class MapMovement : MonoBehaviour {
	
	private GameObject[] Objs;
	private float delay;
	private float randomDelayTime;
	private ObjectSpawnerByOdd odd;
	
	// Use this for initialization
	void Start () {
		Objs = new GameObject[4];
		delay = Time.time;
		randomDelayTime = 1;			
		
		odd = (ObjectSpawnerByOdd)GetComponent(typeof(ObjectSpawnerByOdd));//TODO: is there a way to clean it?
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (Time.time - delay > randomDelayTime){
			for (int i = 0; i < 4; i++){
				if (Objs[i] == null){
					GameObject spawn = odd.getObject();
					if (spawn == null)
						continue;
					
					Objs[i] = (GameObject) Instantiate(spawn,
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
		int rand = (int)Random.Range(-1,2);// equivale a [-1 à 1]
		return 5 * rand;
	}		
}
