using UnityEngine;
using System.Collections;

public class GamePlayTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print(GamePlay.Instance.isTestingFor(GamePlay.TestType.MoveThroughSolids));
	}
}
