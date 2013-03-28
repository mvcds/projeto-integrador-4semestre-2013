using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PI.General;


public class Test : MonoBehaviour{
	private static  bool isTest = true;
	public bool moveThroughWalls;
	public bool teleport;
	public bool quest;
	public bool hud;
	
	private static Dictionary<TestType, bool> testList = new Dictionary<TestType, bool>();
	public enum TestType
	{
		MoveThroughSolids = 0,
		Teleport,
		Quest,
		HUD
	}
		
	// Use this for initialization
	void Start () {
		if (GamePlay.Instance.Quests.Count != Quest.Count)
			throw new ExitGUIException();	
		//GamePlay.Instance.PlayerQuest = null;		
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
		testList.Add(TestType.Quest, quest);
		testList.Add(TestType.HUD, hud);
	}
}