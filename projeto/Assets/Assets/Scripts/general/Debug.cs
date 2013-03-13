using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Debug : MonoBehaviour{
	private static  bool isTest = true;
	public bool moveThroughWalls;
	public bool teleport;
	
	private static Dictionary<TestType, bool> testList = new Dictionary<TestType, bool>();
	public enum TestType
	{
		MoveThroughSolids = 0,
		Teleport
	}
		
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	public static bool isTesting(TestType t){
		return (isTest && testList[t]);
	}
	
	
	
	// Update is called once per frame
	void Update () {
		testList.Clear();
		testList.Add(TestType.MoveThroughSolids, moveThroughWalls);
		testList.Add(TestType.Teleport, teleport);
	}
}
