using UnityEngine;
using System.Collections;

namespace PI.General
{
	public class GamePlayTest : MonoBehaviour {
	
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			print(Test.isTesting(Test.TestType.MoveThroughSolids));
		}
	}
}
