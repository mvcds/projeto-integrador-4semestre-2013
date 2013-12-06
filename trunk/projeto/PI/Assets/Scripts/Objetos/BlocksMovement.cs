using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ObjectSpawnerByOdd))]
public class BlocksMovement : MonoBehaviour {
	
	public GameObject lastBlock;
	public GameObject middleBlock;
	public GameObject currentBlock;
	private ObjectSpawnerByOdd odd;
    //public float levelVelocity = 15;
	
	// Use this for initialization
	void Start () {
		
		odd = (ObjectSpawnerByOdd)GetComponent(typeof(ObjectSpawnerByOdd));//TODO: is there a way to clean it?
		
		GameObject spawn3 = odd.getObject();
		lastBlock = (GameObject)Instantiate(spawn3, new Vector3(0, 0, 35.0f), Quaternion.Euler(new Vector3(0,0,0)));
        odd.FeedDictionary(spawn3);

		GameObject spawn = odd.getObject();
		middleBlock = (GameObject)Instantiate(spawn, new Vector3(0, 0, 60.0f), Quaternion.Euler(new Vector3(0,0,0)));
        odd.FeedDictionary(spawn);

		GameObject spawn2 = odd.getObject();
		currentBlock = (GameObject)Instantiate(spawn2, new Vector3(0, 0, 85.0f), Quaternion.Euler(new Vector3(0,0,0)));
        odd.FeedDictionary(spawn2);
    }
	
	void FixedUpdate () {
		
		if (!Director.Instance.isRunning || PlayerStatus.hasGameOverHappend)
			return;
		
		if (PlayerStatus.powerUp == PlayerStatus.PowerUp.Boia){
			MainScript.gameVelocity += (Time.deltaTime / (20 * MainScript.floatSpeed));
			
		} else {
			MainScript.gameVelocity += (Time.deltaTime / 20);
		}
        if (MainScript.gameVelocity > MainScript.maxspeed)
            MainScript.gameVelocity = MainScript.maxspeed;

		if (lastBlock == null){
			
			GameObject spawn = odd.getObject();
            odd.FeedDictionary(spawn);
						
			if (spawn == null)
				return;
			
			lastBlock = middleBlock;
			middleBlock = currentBlock;			
			
			currentBlock = (GameObject)Instantiate(spawn, new Vector3(0, 0, 55.0f), Quaternion.Euler(new Vector3(0,0,0)));	
		}
		
		if (middleBlock.transform.position.z < -15){
			Destroy(lastBlock);	
		}
	}
}
