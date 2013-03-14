using UnityEngine;
using System.Collections;

public class GamePlayTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print(Test.isTesting(Test.TestType.MoveThroughSolids));
	}
}
