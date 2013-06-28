using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Make it less unity's dependent
public class GeneralTest : MonoBehaviour {
	#region Proprieties
	private static bool isTest = true;
	public bool Quest;
	public bool HUD;
	
	private static Dictionary<Type, bool> tests = new Dictionary<Type, bool>();
	
	public enum Type
	{
		Quest = 0,
		HUD
	}
	#endregion
	
	#region Methods
	void Start()
	{
		//Keeps this script running though scenes
		DontDestroyOnLoad(this);
	}
	
	public static bool isTesting(Type type)
	{
		return (isTest && tests[type]);
	}
	
	//Called to update game designers inputs about tests
	void Update()
	{
		tests.Clear();
		tests.Add(Type.Quest, Quest);
		tests.Add(Type.HUD, HUD);
	}
	#endregion
}
