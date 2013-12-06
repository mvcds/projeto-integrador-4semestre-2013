using UnityEngine;
using System.Collections;

public class WallMov : MonoBehaviour {

	public GameObject rightWall;
	public GameObject leftWall;
	
	public GameObject rightCurrentBlock;
	public GameObject rightMiddleBlock;
	public GameObject rightLastBlock;
	
	public GameObject leftCurrentBlock;
	public GameObject leftMiddleBlock;
	public GameObject leftLastBlock;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//if (PlayerStatus.hasGameOverHappend)
			//return;
		
		if (rightCurrentBlock.transform.position.z < -10){
			
			Destroy(rightCurrentBlock);
			Destroy (leftCurrentBlock);
			
			rightCurrentBlock = rightMiddleBlock;
			rightMiddleBlock = rightLastBlock;
			
			leftCurrentBlock = leftMiddleBlock;
			leftMiddleBlock = leftLastBlock;
			
			rightLastBlock = (GameObject) Instantiate(rightWall,
			new Vector3(9 + (Random.Range(0.0f, 0.75f)), 2, 65.0f), Quaternion.Euler(new Vector3(0,0,0)));
			
			leftLastBlock = (GameObject) Instantiate(leftWall,
			new Vector3(-9.35f + (Random.Range(0.0f, 0.75f)), 2, 65.0f), Quaternion.Euler(new Vector3(0,0,0)));
		}

	}			
}
