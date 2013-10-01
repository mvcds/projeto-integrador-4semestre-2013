using UnityEngine;
using System.Collections;

public class WallMov : MonoBehaviour {

	public GameObject[] Walls;
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
		
		if (rightLastBlock == null){
			rightLastBlock = rightMiddleBlock;
			rightMiddleBlock = rightCurrentBlock;
			
			leftLastBlock = leftMiddleBlock;
			leftMiddleBlock = leftCurrentBlock;
			
			rightCurrentBlock = (GameObject) Instantiate(Walls[Random.Range (0, Walls.Length)],
			new Vector3(7.45f + (Random.Range(0.0f, 0.75f)), 2, 50.0f), Quaternion.Euler(new Vector3(0,0,0)));
			
			leftCurrentBlock = (GameObject) Instantiate(Walls[Random.Range (0, Walls.Length)],
			new Vector3(-7.8f + (Random.Range(0.0f, 0.75f)), 2, 50.0f), Quaternion.Euler(new Vector3(0,0,0)));
		}
		
		if (rightCurrentBlock.transform.position.z < 0 || rightMiddleBlock.transform.position.z < 0){
			Destroy(rightLastBlock);
			Destroy (leftLastBlock);
		}
	}			
}
