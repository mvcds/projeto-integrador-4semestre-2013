using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlay {
	
	#region Singleton's Definition	
	private static GamePlay instance;
	
	private GamePlay()
	{
		//Setting Debugs
		testList.Add(TestType.MoveThroughSolids, false);
	}
	
	/// <summary>
	/// Just a little trick to assure there's just one GamePlay class running in a game session
	/// </summary>
	/// <value>
	/// The instance.
	/// </value>
	public static GamePlay Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new  GamePlay();	
			}
			return instance;			
		}
	}	
	#endregion
	
	#region Game Tests and debugging	
	private static  bool isTest = true;
	private static Dictionary<TestType, bool> testList = new Dictionary<TestType, bool>();
	
	public enum TestType
	{
		MoveThroughSolids = 0
	}		
	
	public bool isTestingFor(TestType t)
	{
		return (isTest && testList[t]);
	}	
	#endregion
		
	#region Game Events & Progression
	//TODO: implement game events/progression
	/*
	 * Mission System
	 * Events
	 * ...
	 */
	#endregion
	
	#region Game Settings
	//TODO: implement game settings
	/*
	 * Sound Effects
	 * Music
	 * Difficulty
	 * ...
	 */
	#endregion
	
	#region Game Inventory
	//TODO: implement game inventory
	/*
	 * Modifications
	 * Costs
	 * ...
	 */
	#endregion
	
	#region Game Screens
	//TODO: implement game screens
	/*
	 * Splash
	 * Main Menu
	 * Game per si
	 * Credits Screen
	 * Etc
	 */
	#endregion
}

